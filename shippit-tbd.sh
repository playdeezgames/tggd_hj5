dotnet publish ./src/TbdOfSPLORR/TbdOfSPLORR.vbproj -o ./pub-linux-tbd -c Release --sc -r linux-x64
dotnet publish ./src/TbdOfSPLORR/TbdOfSPLORR.vbproj -o ./pub-windows-tbd -c Release --sc -r win-x64
butler push pub-windows-tbd thegrumpygamedev/tbd-of-splorr:windows
butler push pub-linux-tbd thegrumpygamedev/tbd-of-splorr:linux
git add -A
git commit -m "shipped it!"