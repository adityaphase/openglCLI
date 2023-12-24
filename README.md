Command line interface for running shaders written in GLSL (for shader art coding).</br>
Options:</br>
```
-f <path to fragment shader file> : Input file
-d                                : docs
-h                                : help
```
Publish a release version by running from OpenGL_CLI/</br>
```
dotnet publish -c Release -o publish -p:PublishReadyToRun=true -p:PublishSingleFile=true --self-contained true -p:IncludeNativeLibrariesForSelfExtract=true
```
Last tested build was on .net 8.0 </br>
</br>
Example credits: https://www.shadertoy.com/view/mtyGWy </br>
