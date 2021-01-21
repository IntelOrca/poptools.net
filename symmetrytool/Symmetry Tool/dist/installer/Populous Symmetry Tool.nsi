; Populous Symmetry Tool.nsi
;--------------------------------

; The name of the installer
Name "Populous Symmetry Tool"

; The file to write
OutFile "SymmetryToolInstall.exe"

; The default installation directory
InstallDir "$PROGRAMFILES\TedTycoon\Populous Symmetry Tool\"

; Registry key to check for directory (so if you install again, it will 
; overwrite the old one automatically)
InstallDirRegKey HKLM "Software\SymmetryTool" "Install_Dir"

;--------------------------------

; Pages

Page components
Page directory
Page instfiles

UninstPage uninstConfirm
UninstPage instfiles

;--------------------------------

; The stuff to install
Section "Populous Symmetry Tool (required)"

  SectionIn RO
  
  ; Set output path to the installation directory.
  SetOutPath $INSTDIR
  
  ; Put files there
  File "SymmetryTool.exe"
  File "help.chm"
  
  ; Write the installation path into the registry
  WriteRegStr HKLM SOFTWARE\SymmetryTool "Install_Dir" "$INSTDIR"
  
  ; Write the uninstall keys for Windows
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\SymmetryTool" "DisplayName" "Populous Symmetry Tool"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\SymmetryTool" "UninstallString" '"$INSTDIR\uninstall.exe"'
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\SymmetryTool" "NoModify" 1
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\SymmetryTool" "NoRepair" 1
  WriteUninstaller "uninstall.exe"
  
SectionEnd

; Optional section (can be disabled by the user)
Section "Start Menu Shortcuts"

  CreateDirectory "$SMPROGRAMS\TedTycoon\"
  CreateShortCut "$SMPROGRAMS\TedTycoon\Symmetry Tool.lnk" "$INSTDIR\SymmetryTool.exe" "" "$INSTDIR\SymmetryTool.exe" 0
  
SectionEnd

;--------------------------------

; Uninstaller

Section "Uninstall"
  
  ; Remove registry keys
  DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\SymmetryTool"
  DeleteRegKey HKLM SOFTWARE\SymmetryTool

  ; Remove files and uninstaller
  Delete $INSTDIR\SymmetryTool.exe
  Delete $INSTDIR\help.chm
  Delete $INSTDIR\uninstall.exe

  ; Remove shortcuts, if any
  Delete "$SMPROGRAMS\TedTycoon\Symmetry Tool.lnk"

  ; Remove directories used
  RMDir "$INSTDIR"

SectionEnd
