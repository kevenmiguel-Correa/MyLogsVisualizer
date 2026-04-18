# MyLogsVisualizer (WPF)

Aplicación de escritorio desarrollada en WPF para visualizar archivos de logs generados con Serilog de forma clara y organizada.

---

##  Requisitos

Antes de comenzar, asegúrate de tener instalado:

- .NET 8 SDK  
- Visual Studio (recomendado)  

---

##  Instalación y ejecución

Sigue estos pasos:

### 1. Clonar el proyecto

```bash
git clone <URL_DEL_REPOSITORIO>
```

Luego entra a la carpeta:

```bash
cd MyLogsVisualizer
```

---

### 2. Compilar la aplicación

Puedes compilar desde Visual Studio o desde consola:

```bash
dotnet build
```

---

### 3. Ubicar el ejecutable

Después de compilar, navega a la siguiente ruta:

```
bin/Debug/net8.0-windows/
```

Dentro encontrarás el archivo:

```
MyLogsVisualizer.exe
```

---

### 4. Crear acceso directo (shortcut)

Para facilitar el acceso:

1. Haz clic derecho sobre `MyLogsVisualizer.exe`
2. Selecciona **"Crear acceso directo"**
3. Mueve el acceso directo al escritorio o donde prefieras

---

##  Uso de la aplicación

1. Ejecuta la aplicación
2. Haz clic en **"Cargar Log"**
3. Selecciona un archivo `.log` o `.txt`
4. Visualiza:
   - Tiempo
   - Nivel (Information, Warning, Error, Debug)
   - Mensaje

Puedes usar la barra de búsqueda para filtrar logs rápidamente.

---

## Características

- Visualización de logs en formato tabla
- Colores por nivel de log
- Búsqueda en tiempo real
- Soporte para logs largos (auto ajuste / wrap)
- Interfaz oscura (dark mode)

---

## Notas

- La aplicación está diseñada para logs con formato tipo Serilog:

```
[2026-03-25 00:03:25 INF] Mensaje...
```

- Archivos muy grandes pueden afectar el rendimiento.

---

## Posibles mejoras a futuro (opcional)

- Exportar logs filtrados  
- Resaltado de errores  
- Soporte para JSON formateado  
- Auto-refresh en tiempo real  
