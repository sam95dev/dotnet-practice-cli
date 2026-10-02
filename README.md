## CLI with Spectre.Console

Este proyecto usa Spectre.Console para crear un CLI en dotnet.

El programa lee un archivo de texto y muestra su contenido en la consola.

## Uso

Desde la raiz

```bash
dotnet run --project ./App -- read file ./App/Program.cs -m 3
```

Desde el folder `App` (uso preferido)

```bash
dotnet run -- read file Program.cs -m 3
```

Salida

```bash
❯ dotnet run -- read file Program.cs -m 3
Reading file: /<path/to/the/file>/App/Program.cs
------------------------------------------------------------------
using System.CommandLine;
using System.CommandLine.Parsing;
using App.Option;
```

Mostrar help

```bash
dotnet run -- --help
```

## Opciones

- `--file <path>`: Ruta al archivo a leer.
- `--max-read-lines <count>`: Número máximo de líneas a leer.
- `--help`: Muestra la ayuda.
