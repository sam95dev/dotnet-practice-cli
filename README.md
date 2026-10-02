## CLI with System.CommandLine

Este proyecto usa System.CommandLine para crear un CLI en Dotnet.


El programa lee un archivo de texto y muestra su contenido en la consola.

## Uso

Desde la raiz

```bash
dotnet run --project ./App -- --file ./App/Program.cs -m 3
```

Desde el folder `App` (uso preferido)

```bash
dotnet run -- --file Program.cs -m 3
```

Salida

```bash
❯ dotnet run -- --file Program.cs -m 3
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

### Notas del desarrollador

Este proyecto es para verificar o demostrar el uso de System.CommandLine.

Sin embargo tras diferentes busquedas no hay una forma ofical de crear una CLI
usando System.CommandLine para dividir un proyecto en multiples archivos de C#.

En proximos commits se modificará/refactorizará el proyecto para hacerlo más modular usando librerias externas.
