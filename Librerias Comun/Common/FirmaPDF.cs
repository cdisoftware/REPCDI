using System;
using System.Collections;
using System.IO;
using System.Security.Cryptography;
using iTextSharp.text.pdf;
using iTextSharp.text;
using SysX509 = System.Security.Cryptography.X509Certificates;
using Bouncy = Org.BouncyCastle.X509;


// compile with: /target:iTextSharp.text.pdf  4.1.2.0
namespace CDI.Common
{
    public class FirmaPDF
    {
        /// <summary>
        /// Firma un documento
        /// </summary>
        /// <param name="Source">Documento origen</param>
        /// <param name="Target">Documento destino</param>
        /// <param name="Certificate">Certificado a utilizar</param>
        /// <param name="Reason">Razón de la firma</param>
        /// <param name="Location">Ubicación</param>
        /// <param name="AddVisibleSign">Establece si hay que agregar la firma visible al documento</param>
        public static void SignHashed(byte[] PDFBytes, string Target, SysX509.X509Certificate2 Certificate, string Reason, string Location, bool AddVisibleSign)
        {
            Bouncy.X509CertificateParser objCP = new Bouncy.X509CertificateParser();
            Bouncy.X509Certificate[] objChain = new Bouncy.X509Certificate[] { objCP.ReadCertificate(Certificate.RawData) };

            PdfReader objReader = new PdfReader(PDFBytes);            
            PdfStamper objStamper = PdfStamper.CreateSignature(objReader, new FileStream(Target, FileMode.Create), '\0');
            PdfSignatureAppearance objSA = objStamper.SignatureAppearance;

            if (AddVisibleSign)
                objSA.SetVisibleSignature(new Rectangle(100, 100, 300, 200), 1, null);

            objSA.SignDate = DateTime.Now;
            objSA.SetCrypto(null, objChain, null, null);
            objSA.Reason = Reason;
            objSA.Location = Location;
            objSA.Acro6Layers = true;
            objSA.Render = PdfSignatureAppearance.SignatureRender.NameAndDescription;
            PdfSignature objSignature = new PdfSignature(PdfName.ADOBE_PPKMS, PdfName.ADBE_PKCS7_SHA1);
            objSignature.Date = new PdfDate(objSA.SignDate);
            objSignature.Name = PdfPKCS7.GetSubjectFields(objChain[0]).GetField("CN");
            if (objSA.Reason != null)
                objSignature.Reason = objSA.Reason;
            if (objSA.Location != null)
                objSignature.Location = objSA.Location;
            objSA.CryptoDictionary = objSignature;
            int intCSize = 4000;
            Hashtable objTable = new Hashtable();
            objTable[PdfName.CONTENTS] = intCSize * 2 + 2;
            objSA.PreClose(objTable);

            HashAlgorithm objSHA1 = new SHA1CryptoServiceProvider();

            Stream objStream = objSA.RangeStream;
            int intRead = 0;
            byte[] bytBuffer = new byte[8192];
            while ((intRead = objStream.Read(bytBuffer, 0, 8192)) > 0)
                objSHA1.TransformBlock(bytBuffer, 0, intRead, bytBuffer, 0);
            objSHA1.TransformFinalBlock(bytBuffer, 0, 0);

            //byte[] bytPK = SignMsg(objSHA1.Hash, Certificate, false);
            byte[] bytOut = new byte[intCSize];

            PdfDictionary objDict = new PdfDictionary();

            //Array.Copy(bytPK, 0, bytOut, 0, bytPK.Length);

            objDict.Put(PdfName.CONTENTS, new PdfString(bytOut).SetHexWriting(true));
            objSA.Close(objDict);
        }

    }
}