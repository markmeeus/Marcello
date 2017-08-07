C:\"Program Files (x86)"\"Microsoft Visual Studio"\2017\Community\MSBuild\15.0\Bin\MsBuild.Exe .\MarcelloDB.sln


Remove-Item -Recurse -Force Package\lib
mkdir Package\lib
mkdir Package\lib\net45
mkdir Package\lib\MonoAndroid
mkdir Package\lib\Xamarin.iOS
mkdir Package\lib\MonoTouch
mkdir Package\lib\Xamarin.Mac
mkdir Package\lib\portable-net45+win+wp80+wp81+MonoTouch10+MonoAndroid10+xamarinmac20+xamarinios10
mkdir Package\lib\netstandard1.1

cp MarcelloDB\bin\debug\MarcelloDB.dll Package\lib\net45\MarcelloDB.dll
cp MarcelloDB.netfx\bin\debug\MarcelloDB.netfx.dll Package\lib\net45\MarcelloDB.netfx.dll

cp MarcelloDB\bin\debug\MarcelloDB.dll Package\lib\MonoAndroid\MarcelloDB.dll
cp MarcelloDB.netfx\bin\debug\MarcelloDB.netfx.dll Package\lib\MonoAndroid\MarcelloDB.netfx.dll

cp MarcelloDB\bin\debug\MarcelloDB.dll Package\lib\MonoTouch\MarcelloDB.dll
cp MarcelloDB.netfx\bin\debug\MarcelloDB.netfx.dll Package\lib\MonoTouch\MarcelloDB.netfx.dll

cp MarcelloDB\bin\debug\MarcelloDB.dll Package\lib\Xamarin.iOS\MarcelloDB.dll
cp MarcelloDB.netfx\bin\debug\MarcelloDB.netfx.dll Package\lib\Xamarin.iOS\MarcelloDB.netfx.dll

cp MarcelloDB\bin\debug\MarcelloDB.dll Package\lib\Xamarin.Mac\MarcelloDB.dll
cp MarcelloDB.netfx\bin\debug\MarcelloDB.netfx.dll Package\lib\Xamarin.Mac\MarcelloDB.netfx.dll

cp MarcelloDB\bin\debug\MarcelloDB.dll Package\lib\portable-net45+win+wp80+wp81+MonoTouch10+MonoAndroid10+xamarinmac20+xamarinios10\MarcelloDB.dll

cp MarcelloDB\bin\debug\netstandard1.1\MarcelloDB.dll Package\lib\netstandard1.1

nuget.exe pack Package\MarcelloDB.nuspec