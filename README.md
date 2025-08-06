# PrimePenguinSharp: A .NET library for PrimePenguin.


## Steps to Generate SDK
- Open PrimePenguinService.nswag in NSwagStudio and get fresh copy for Schema.
- Generate the file with new schema
- Use VSCode to Open the generated PrimePenguinService.cs file.
- Search & Replace `System.DateTime` with `DateTime`
- Search & Replace `public System.Collections.Generic.IEnumerable` with `public System.Collections.Generic.List`
- Search & Replace the following with empty character:
    - System.Threading.Tasks.
    - Newtonsoft.Json.
    - System.Collections.Generic.
- Add the following using statements:
    - `using System;`
    - `using System.Threading.Tasks;`
    - `using System.Collections.Generic;`
    - `using Newtonsoft.Json;`
- Search & Replace `Task<List<` with `Ta11111sk<List<`.
- Search & Replace `ReadObjectResponseAsync<List<` with `Read11111ObjectResponseAsync<List<`.
- Select `Task<` and press `CTRL + SHIFT + L` to select all occurences. Append `PrimePenguinResponse<` and press `Shift + >` and close the last word with `>`.
    - Example: `Task<PagedResultDtoOfContractFileDto>` will be replaced by `Task<PrimePenguinResponse<PagedResultDtoOfContractFileDto>>`.
- Select `ReadObjectResponseAsync<` and press `CTRL + SHIFT + L` to select all occurences. Append `PrimePenguinResponse<` and press `Shift + >` and close the last word with `>`.
- Select `Ta11111sk<` and press `CTRL + SHIFT + L` to select all occurences. Replace with `Task<PrimePenguinResponse<` and press `Shift + >` twice and close the last word with `>`.
- Select `Read11111ObjectResponseAsync<` and press `CTRL + SHIFT + L` to select all occurences. Replace with `ReadObjectResponseAsync<PrimePenguinResponse<` and press `Shift + >` twice and close the last word with `>`.
- Search & Replace the following with empty character:
    - , Required = Required.Default
    - , Required = Required.DisallowNull
- Replace `Task<PrimePenguinResponse<ObjectResponseResult><T>> ReadObjectResponseAsync<PrimePenguinResponse<T>>` with `Task<ObjectResponseResult<T>> ReadObjectResponseAsync<T>`.
- Manually fix the `foreach` loops that take list of objects as input.
```cs
if (customerTenantIds != null)
{
    urlBuilder_.Append(System.Uri.EscapeDataString("CustomerTenantIds") + "=");
    foreach (var item_ in customerTenantIds)
    {
        urlBuilder_.Append(System.Uri.EscapeDataString(ConvertToString(item_, System.Globalization.CultureInfo.InvariantCulture))).Append(",");
    }
    urlBuilder_.Length--;
    urlBuilder_.Append("&");
}
```
Should look as
```cs
if (customerTenantIds != null)
{
    foreach (var item_ in customerTenantIds)
    {
        urlBuilder_.Append(System.Uri.EscapeDataString("CustomerTenantIds") + "=")
        .Append(System.Uri.EscapeDataString(ConvertToString(item_, System.Globalization.CultureInfo.InvariantCulture))).Append('&');
    }
    urlBuilder_.Length--;
    urlBuilder_.Append("&");
}
```