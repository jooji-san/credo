using System.Globalization;

string srcDirPath = args[0];
string destDirPath = args[2];
if (!Directory.Exists(srcDirPath) || !Directory.Exists(destDirPath))
{
    Console.WriteLine("At least one of the paths is wrong");
    return;
}

string dateString = args[1];
DateOnly date;
try
{
    date = DateOnly.ParseExact(dateString, "dd/mm/yyyy", CultureInfo.InvariantCulture);
}
catch (Exception)
{
    Console.WriteLine("enter the date correctly. The accepted format is: dd/mm/yyyy");
    return;
}

string[] srcFilePaths = Directory.GetFiles(srcDirPath);

foreach (string srcFilePath in srcFilePaths)
{
    DateOnly creationDate = DateOnly.FromDateTime(File.GetCreationTime(srcFilePath));
    if (date.CompareTo(creationDate) <= 0)
    {
        string destFilePath = Path.Combine(destDirPath, srcFilePath.Substring(srcDirPath.Length + 1));
        if (File.Exists(destFilePath))
        {
            File.Delete(destFilePath);
        }
        File.Move(srcFilePath, destFilePath);
    };
}