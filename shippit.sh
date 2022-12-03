dotnet publish ./src/tggd_hj5/tggd_hj5.vbproj -o ./pub-linux -c Release --sc -r linux-x64
dotnet publish ./src/tggd_hj5/tggd_hj5.vbproj -o ./pub-windows -c Release --sc -r win-x64
butler push pub-windows thegrumpygamedev/tggd-hj5:windows
butler push pub-linux thegrumpygamedev/tggd-hj5:linux
git add -A
git commit -m "shipped it!"