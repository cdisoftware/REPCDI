using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using CDI.Common;
using System.Text.RegularExpressions;

public class ClassPass
{
    // Define default min and max password lengths.
    private static int TamMaxPass = 16;
    private static int TamMinPass = 8;

    // Define supported password characters divided into groups.
    // You can add (or remove) characters to (from) these groups.
    private static string LetsMin = "abcdefgijkmnopqrstwxyz";
    private static string LetsMay = "ABCDEFGHJKLMNPQRSTWXYZ";
    private static string Numrs = "0123456789";
    private static string CartsSpcl = "*-+_.$#@";

    /// <summary>
    /// Generates a random password.
    /// </summary>
    /// <returns>
    /// Randomly generated password.
    /// </returns>
    /// <remarks>
    /// The length of the generated password will be determined at
    /// random. It will be no shorter than the minimum default and
    /// no longer than maximum default.
    /// </remarks>
    public static string Generate()
    {
        return Generate(TamMinPass,
                        TamMaxPass);
    }

    /// <summary>
    /// Generates a random password of the exact length.
    /// </summary>
    /// <param name="length">
    /// Exact password length.
    /// </param>
    /// <returns>
    /// Randomly generated password.
    /// </returns>
    public static string Generate(int length)
    {
        return Generate(length, length);
    }

    /// <summary>
    /// Generar password aleatorio.
    /// </summary>
    /// <param name="minLength">
    /// Longitud minima.
    /// </param>
    /// <param name="maxLength">
    /// Longitud maxima.
    /// </param>
    /// <returns>
    /// Password aleatorio
    /// </returns>
    /// <remarks>

    /// </remarks>
    public static string Generate(int minLength,
                                  int maxLength)
    {
        // Make sure that input parameters are valid.
        if (minLength <= 0 || maxLength <= 0 || minLength > maxLength)
            return null;

        // Create a local array containing supported password characters
        // grouped by types. You can remove character groups from this
        // array, but doing so will weaken the password strength.
        char[][] charGroups = new char[][]
        {
            LetsMin.ToCharArray(),
            LetsMay.ToCharArray(),
            Numrs.ToCharArray(),
            CartsSpcl.ToCharArray()
        };

        // Use this array to track the number of unused characters in each
        // character group.
        int[] charsLeftInGroup = new int[charGroups.Length];


        for (int i = 0; i < charsLeftInGroup.Length; i++)
            charsLeftInGroup[i] = charGroups[i].Length;


        int[] leftGroupsOrder = new int[charGroups.Length];


        for (int i = 0; i < leftGroupsOrder.Length; i++)
            leftGroupsOrder[i] = i;


        byte[] randomBytes = new byte[4];


        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        rng.GetBytes(randomBytes);


        int seed = (randomBytes[0] & 0x7f) << 24 |
                    randomBytes[1] << 16 |
                    randomBytes[2] << 8 |
                    randomBytes[3];


        Random random = new Random(seed);


        char[] password = null;


        if (minLength < maxLength)
            password = new char[random.Next(minLength, maxLength + 1)];
        else
            password = new char[minLength];

        int nextCharIdx;
        int nextGroupIdx;
        int nextLeftGroupsOrderIdx;


        int lastCharIdx;


        int lastLeftGroupsOrderIdx = leftGroupsOrder.Length - 1;


        for (int i = 0; i < password.Length; i++)
        {

            if (lastLeftGroupsOrderIdx == 0)
                nextLeftGroupsOrderIdx = 0;
            else
                nextLeftGroupsOrderIdx = random.Next(0,
                                                     lastLeftGroupsOrderIdx);


            nextGroupIdx = leftGroupsOrder[nextLeftGroupsOrderIdx];


            lastCharIdx = charsLeftInGroup[nextGroupIdx] - 1;


            if (lastCharIdx == 0)
                nextCharIdx = 0;
            else
                nextCharIdx = random.Next(0, lastCharIdx + 1);


            password[i] = charGroups[nextGroupIdx][nextCharIdx];


            if (lastCharIdx == 0)
                charsLeftInGroup[nextGroupIdx] =
                                          charGroups[nextGroupIdx].Length;

            else
            {

                if (lastCharIdx != nextCharIdx)
                {
                    char temp = charGroups[nextGroupIdx][lastCharIdx];
                    charGroups[nextGroupIdx][lastCharIdx] =
                                charGroups[nextGroupIdx][nextCharIdx];
                    charGroups[nextGroupIdx][nextCharIdx] = temp;
                }

                charsLeftInGroup[nextGroupIdx]--;
            }


            if (lastLeftGroupsOrderIdx == 0)
                lastLeftGroupsOrderIdx = leftGroupsOrder.Length - 1;

            else
            {

                if (lastLeftGroupsOrderIdx != nextLeftGroupsOrderIdx)
                {
                    int temp = leftGroupsOrder[lastLeftGroupsOrderIdx];
                    leftGroupsOrder[lastLeftGroupsOrderIdx] =
                                leftGroupsOrder[nextLeftGroupsOrderIdx];
                    leftGroupsOrder[nextLeftGroupsOrderIdx] = temp;
                }

                lastLeftGroupsOrderIdx--;
            }
        }


        return new string(password);
    }


    public string removeRepeatedChars(string pwd)
    {
        char[] arrStr = pwd.ToCharArray();
        Array.Sort(arrStr);
        StringBuilder str = new StringBuilder();
        int i;
        for (i = 0; i < arrStr.Length; i++)
            str.Append(arrStr[i].ToString());
        i = 0;
        while (i < str.Length - 1)
        {
            if (str[i + 1] == str[i])
                str.Remove(i + 1, 1);
            //text = "";
            else
                i++;
        }
        return str.ToString();
    }


    char[] ValueAfanumeric = { 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p', 'a', 's',
                               'd', 'f', 'g', 'h', 'j', 'k', 'l', 'z', 'x', 'c', 'v', 'b',
                               'n', 'm', 'Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P',
                               'A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'Z', 'X', 'C',
                               'V', 'B', 'N', 'M',  '#',  '.', '@', '-', '_', '1' , '2', '3', '4',
                               '5', '6', '7', '8', '9', '0'};

    public string GenerarPass(int TamMinPass, int TamMaxPass)
    {
        Random ram = new Random();
        int LogitudPass = ram.Next(TamMinPass, TamMaxPass);
        string Password = String.Empty;

        for (int i = 0; i < LogitudPass; i++)
        {
            int rm = ram.Next(0, 2);

            if (rm == 0)
            {
                Password += ram.Next(0, 10);
            }
            else
            {
                Password += ValueAfanumeric[ram.Next(0, 59)];
            }
        }
        return Password;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static string EncrMD5(string text)
    {
        MD5 md5 = new MD5CryptoServiceProvider();
        md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
        byte[] result = md5.Hash;
        StringBuilder strBuilder = new StringBuilder();

        for (int i = 0; i <= result.Length - 1; i++)
        {
            strBuilder.Append(result[i].ToString("x2"));
        }
        return strBuilder.ToString();
    }


    /// <summary>
    /// Validación de expresiones regulares
    /// </summary>
    /// <param name="inputString">cadena de texto a validar</param>
    /// <param name="regularExpr">las expresiones a regular</param>
    /// <returns></returns>
    public bool ValidarRegularx(string inputString, string regularExpr)
    {
        Regex r = new Regex(regularExpr);
        if (r.IsMatch(inputString))
            return true;
        else
            return false;
    }



}
