# resharper-fsi-friendly

ReSharper uses Alt+Enter as a keyboard shortcut for lots of lovely stuff. F# also uses Alt+Enter to send the current selection from the F# editor to the F# Interactive window.

You can redefine either shortcut in the Visual Studio Options window, but you can't use the same shortcut for both features, even though neither commands clash.

This plugin tells ReSharper to invoke the send to F# Interactive command if the current text window is an F# fil.

## How do I get it? ##

- Download the latest zip file: [resharper-fsi-friendly.1.0.zip](https://dl.bintray.com/citizenmatt/resharper-plugins/resharper-fsi-friendly.1.0.zip)
- Extract everything
- Run Install-FsiFriendly.7.1.bat