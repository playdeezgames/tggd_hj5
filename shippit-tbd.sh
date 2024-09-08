rm -rf ./pub-linux-tbd
rm -rf ./pub-windows-tbd
rm -rf ./pub-mac-tbd
dotnet publish ./src/TbdOfSPLORR/TbdOfSPLORR.vbproj -o ./pub-linux-tbd -c Release -p:PublishSingleFile=true --sc -r linux-x64
dotnet publish ./src/TbdOfSPLORR/TbdOfSPLORR.vbproj -o ./pub-windows-tbd -c Release -p:PublishSingleFile=true --sc -r win-x64
dotnet publish ./src/TbdOfSPLORR/TbdOfSPLORR.vbproj -o ./pub-mac-tbd -c Release -p:PublishSingleFile=true --sc -r osx-x64
butler push pub-windows-tbd thegrumpygamedev/tbd-of-splorr:windows
butler push pub-linux-tbd thegrumpygamedev/tbd-of-splorr:linux
butler push pub-mac-tbd thegrumpygamedev/tbd-of-splorr:mac
git add -A
git commit -m "shipped it!"