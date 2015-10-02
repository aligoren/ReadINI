#Read INI

ReadINI Class for Read your .ini Files

#Usage:

*Write data in your .ini file*

```
var rini = new ReadINI(@"C:\FakePath\Settings.ini");
rini.Write("Some Key", "Some Value", "Some Section. !Default value null");
```

---------------------------------------------------------------------------

*Read data in your .ini file*

```
var rini = new ReadINI(@"C:\FakePath\Settings.ini");
rini.Read("SomeKey", "SomeSection");
```

---------------------------------------------------------------------------

*Delete key data in your .ini file*

```
var rini = new ReadINI(@"C:\FakePath\Settings.ini");
rini.DeleteKey("Some Key", "Some Section");
```

---------------------------------------------------------------------------

*Delete section data in your .ini file*

```
var rini = new ReadINI(@"C:\FakePath\Settings.ini");
rini.DeleteSection("Some Section");
```

---------------------------------------------------------------------------

*Check Key Exists in your .ini file*

```
var rini = new ReadINI(@"C:\FakePath\Settings.ini");
if(!rini.KeyExists("SomeKey", "SomeSection")
{
	rini.Write("Key", "Val", "Section");
}
```

Thanks! :)