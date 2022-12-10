namespace DiyanetNamazVakti.Api.Core.Heplers;

public static class StringHelper
{
    public static string ClearForHtml(this string str)
    {
        return Regex.Replace(str, @"<[^>]+>|&nbsp;", "").Trim();
    }


    /// <summary>
    /// Enum olarak verilen parametrenin Description de�erini d�nd�r�r.
    /// </summary>
    /// <param name="e">Enum</param>
    /// <returns>string</returns>
    public static string GetEnumDescription(this Enum e)
    {
        return e.GetType().GetMember(e.ToString()).FirstOrDefault()?.GetCustomAttribute<DescriptionAttribute>()?.Description;
    }

    /// <summary>
    /// string olarak verilen parametrenin de�erini SEO'ya (Arama Motoru Optimazsyonu) uygun olarak d�n��t�rerek geri d�nd�r�r.
    /// </summary>
    /// <param name="inputString"></param>
    /// <returns></returns>
    public static string ToStringForSeo(this string inputString)
    {
        inputString = inputString.Replace("�", "c");
        inputString = inputString.Replace("�", "c");
        inputString = inputString.Replace("�", "g");
        inputString = inputString.Replace("�", "g");
        inputString = inputString.Replace("I", "i");
        inputString = inputString.Replace("�", "i");
        inputString = inputString.Replace("�", "i");
        inputString = inputString.Replace("i", "i");
        inputString = inputString.Replace("�", "o");
        inputString = inputString.Replace("�", "o");
        inputString = inputString.Replace("�", "s");
        inputString = inputString.Replace("�", "s");
        inputString = inputString.Replace("�", "u");
        inputString = inputString.Replace("�", "u");
        inputString = inputString.Trim().ToLower();
        inputString = Regex.Replace(inputString, @"\s+", "-");
        inputString = Regex.Replace(inputString, @"[^A-Za-z0-9_-]", "");
        return inputString;
    }

    /// <summary>
    /// string olarak verilen parametrenin de�erindeki kelimelerin ilk harflerini b�y�k harfe �evirir.
    /// </summary>
    /// <param name="str"></param>
    /// <param name="useOriginal">false olmas� durumunda "Ve, �le" ba�la�lar� k���k yap�l�r.</param>
    /// <returns></returns>
    public static string ToTitleCase(this string str, bool useOriginal = false)
    {
        var result = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());

        if (!useOriginal)
        {
            result = result.Replace(" Ve ", " ve ");
            result = result.Replace(" �le ", " ile ");
            return result;
        }
        return result;
    }

    public static string ListToString(this List<string> list, string delimeter)
    {
        return string.Join(delimeter, list.ToArray());
    }

    public static string TemplateParser(this string templateText, string regExString, string value)
    {
        var regExToken = new Regex(regExString, RegexOptions.IgnoreCase);
        return regExToken.Replace(templateText, value);
    }
}