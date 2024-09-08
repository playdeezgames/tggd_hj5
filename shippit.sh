rm -rf ./pub-linux
rm -rf ./pub-windows
rm -rf ./pub-mac
dotnet publish ./src/TbdOfSPLORR/TbdOfSPLORR.vbproj -o ./pub-linux -c Release -p:PublishSingleFile=true --sc -r linux-x64
dotnet publish ./src/TbdOfSPLORR/TbdOfSPLORR.vbproj -o ./pub-windows -c Release -p:PublishSingleFile=true --sc -r win-x64
dotnet publish ./src/TbdOfSPLORR/TbdOfSPLORR.vbproj -o ./pub-mac -c Release -p:PublishSingleFile=true --sc -r osx-x64
butler push pub-windows thegrumpygamedev/tbd-of-splorr:windows
butler push pub-linux thegrumpygamedev/tbd-of-splorr:linux
butler push pub-mac thegrumpygamedev/tbd-of-splorr:mac
git add -A
git commit -m "shipped it!"