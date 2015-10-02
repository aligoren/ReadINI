using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

public class ReadINI
{
    string Path;
    string EXE = Assembly.GetExecutingAssembly().GetName().Name;

    /// <summary>
    /// Write INI File.
    /// Section: [SectionName]
    /// Key: SampleKey=
    /// Value: =KeyValue
    /// FilePath: @"C:\FakePath\Settings.ini"
    /// 
    /// Sample Usage: 
    ///     var rini = new ReadINI(@"C:\FakePath\Settings.ini");
    ///     rini.Write("Some Key", "Some Value", "Some Section. !Default value null");
    /// </summary>
    /// <param name="Section"></param>
    /// <param name="Key"></param>
    /// <param name="Value"></param>
    /// <param name="FilePath"></param>
    /// <returns></returns>
    [DllImport("kernel32")]
    static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

    /// <summary>
    /// Read INI File.
    /// Section: [SectionName]
    /// Key: SampleKey=
    /// Default: Default val
    /// RetVal: return value
    /// Size: Size
    /// FilePath: File location
    /// Sample Usage:
    ///     rini.Read("SomeKey", "SomeSection");
    /// </summary>
    /// <param name="Section"></param>
    /// <param name="Key"></param>
    /// <param name="Default"></param>
    /// <param name="RetVal"></param>
    /// <param name="Size"></param>
    /// <param name="FilePath"></param>
    /// <returns></returns>
    [DllImport("kernel32")]
    static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

    public ReadINI(string IniPath = null)
    {
        Path = new FileInfo(IniPath ?? EXE + ".ini").FullName.ToString();
    }

    /// <summary>
    /// Sample Usage:
    ///     rini.Read("SomeKey", "SomeSection");
    /// </summary>
    /// <param name="Key"></param>
    /// <param name="Section"></param>
    /// <returns></returns>
    public string Read(string Key, string Section = null)
    {
        var RetVal = new StringBuilder(255);
        GetPrivateProfileString(Section ?? EXE, Key, "", RetVal, 255, Path);
        return RetVal.ToString();
    }

    /// <summary>
    /// Sample Usage: 
    ///     var rini = new ReadINI(@"C:\FakePath\Settings.ini");
    ///     rini.Write("Some Key", "Some Value", "Some Section. !Default value null");
    /// </summary>
    /// <param name="Key"></param>
    /// <param name="Value"></param>
    /// <param name="Section"></param>
    public void Write(string Key, string Value, string Section = null)
    {
        WritePrivateProfileString(Section ?? EXE, Key, Value, Path);
    }

    /// <summary>
    /// Delete key in Section:
    /// Sample Usage: 
    ///     var rini = new ReadINI(@"C:\FakePath\Settings.ini");
    ///     rini.DeleteKey("Some Key", "Some Section");
    /// </summary>
    /// <param name="Key"></param>
    /// <param name="Section"></param>
    public void DeleteKey(string Key, string Section = null)
    {
        Write(Key, null, Section ?? EXE);
    }

    /// <summary>
    /// Delete section.
    /// Sample Usage: 
    ///     var rini = new ReadINI(@"C:\FakePath\Settings.ini");
    ///     rini.DeleteSection("Some Section");
    /// </summary>
    /// <param name="Section"></param>
    public void DeleteSection(string Section = null)
    {
        Write(null, null, Section ?? EXE);
    }

    /// <summary>
    /// Check if key exists
    /// /// Sample Usage: 
    ///     var rini = new ReadINI(@"C:\FakePath\Settings.ini");
    ///     if(!rini.KeyExists("SomeKey", "SomeSection")
    ///     {
    ///         rini.Write("Key", "Val", "Section");
    ///     }
    /// </summary>
    /// <param name="Key"></param>
    /// <param name="Section"></param>
    /// <returns></returns>
    public bool KeyExists(string Key, string Section = null)
    {
        return Read(Key, Section).Length > 0;
    }
}
