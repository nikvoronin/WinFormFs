# WinForms ♥ F\#

- Application w-or-without windows
- Windows (Form)
- Menus
    - Subitems
    - Separator
    - Popup menus (ContextMenu)
    - App main menu (MenuStrip)
- System operations
    - Open URL in system browser
- StatusBar (StatusStrip)
- Controls (any descendants of the Control class)
- Layouts
    - Panel
- System tray (NotifyIcon)

## History

```fsharp
printfn $"{``FWinForms Version``}"
```

### 3.5.27-alpha

- `Do` style `FControl.create` and `.setup` to fine tuning of the Control class descendants.

### 3.5.25-alpha

- System tray (NotifyIcon).
- Changed order of arguments, it starts from title now: `"Click me" |> StatusBar.label`
