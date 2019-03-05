# HolisticWare.Core

HolisticWare.Core .NET Standard utilities:

*   basic text utilities based on:

    *   `string`

        *   `netstandard1.0`

        *   Implementation [INPROGRESS]

        *   Tests [INPROGRESS]

    *   `Span<T>` and `Memory<T>` from `System.Memory`  with `string` like API 

        *   `string` like API - from `Core` (`HolisticWare.Core` package/project/repo)

        *   idea behind is to have `string` like API for `Memory<char>`

            *   replacing `string` with `Memory<char>` should not involve code breaking

            *   `using string = Memory<char>;`
    
        *   `netstandard1.1`

        *   Implementation [INPROGRESS]

        *   Tests [INPROGRESS]

*   more 1

*   more 2


## .NET Standard Porting help

*   [http://packagesearch.azurewebsites.net/](http://packagesearch.azurewebsites.net/)

*   [https://apisof.net/](https://apisof.net/)

*   [https://docs.microsoft.com/en-us/dotnet/api/](https://docs.microsoft.com/en-us/dotnet/api/)

## Features

*   several shims/polyfills not available in >NET Standard and PCLs 
*   ToString("FORMAT")for objects (Tracing, Debugging)
*     


## References / Links

