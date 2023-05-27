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
    - Label
    - ProgressBar
    - Separator
- Controls (any descendants of the Control class)
- Layouts
    - Panel
- System tray (NotifyIcon)

## History

```fsharp
printfn $"{``FWinForms Version``}"
```

### 3.5.xx-alpha

- Add flow layout panels aka stackPanel (both horizontal and vertical).
- Add `ProgressBar` for `StatusBar`.
- `Do` style `Ctrl.create|setup` to fine tuning descendants of the Control class.
- System tray (NotifyIcon).
- Changed order of arguments, it starts from title now: `"Click me" |> StatusBar.label`.
