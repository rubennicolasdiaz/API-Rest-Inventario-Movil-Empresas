# 🚀 API Rest Inventario Móvil Empresas
[![Build Status](https://github.com/rubennicolasdiaz/spring-boot-email/actions/workflows/build.yml/badge.svg?branch=master)](https://github.com/rubennicolasdiaz/spring-boot-email/actions/workflows/build.yml)
![Java](https://img.shields.io/badge/Java-21-blue?logo=openjdk)
![Spring Boot](https://img.shields.io/badge/Spring%20Boot-3.5.5-brightgreen?logo=springboot)
![Docker](https://img.shields.io/badge/Docker-Ready-blue?logo=docker)
![Status](https://img.shields.io/badge/Status-Active-success)
![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)

---

## 📚 Índice

- [📖 Descripción](#-descripción)
- [⚙️ Tecnologías y Herramientas](#️-tecnologías-y-herramientas)
- [📦 Arquitectura del Proyecto](#-arquitectura-del-proyecto)
- [🧠 Funcionamiento](#-funcionamiento)
- [🔐 Seguridad](#-seguridad)
- [🎥 Vídeo explicativo en YouTube](#-vídeo-explicativo-en-youtube)
- [🧾 Licencia](#-licencia)
- [🧑‍💻 Autor](#-autor)

---

## 📖 Descripción

**API Rest Inventario Móvil Empresas** es una API Rest para cargar y descargar ficheros .json creada con .NET 9 y lenguaje C#, pensada para ser consumida por una app Android para el control y gestión de inventarios de diferentes empresas. 

---

## ⚙️ Tecnologías y Herramientas

🟦 C# 13 / .NET 9 

🌐 ASP.NET Core 9 

💿 NuGet / .NET CLI 

🔧 GitHub Actions (CI/CD) 

---

## 📦 Arquitectura del Proyecto

```text
APIRestInventarioMovilEmpresas/
├── APIRestInventarioMovilEmpresas/                     # Proyecto principal
│   ├── Program.cs                                      # Entry point
│   ├── Controllers/
│   │   ├── LoginAPIController.cs                       # Endpoints relacionados a login
│   │   └── UploadDownloadFilesController.cs           # Endpoints de subida/descarga
│   ├── DTO/
│   │   └── UsuarioApiDTO.cs                            # DTO para usuarios
│   ├── Services/
│   │   ├── IServicioSupabase.cs                        # Interfaz del servicio Supabase
│   │   ├── ServicioSupabase.cs                         # Implementación de Supabase
│   │   ├── IUploadDownloadFileService.cs               # Interfaz para archivos
│   │   └── UploadDownloadFileService.cs               # Implementación de subida/descarga
│   ├── Models/
│   │   ├── LoginAPI.cs                                 # Modelo de login
│   │   └── Usuario.cs                                  # Modelo de usuario
│   ├── Files/
│   │   ├── DeleteFileRequest.cs
│   │   ├── DownloadFileRequest.cs
│   │   ├── DownloadFileResponse.cs
│   │   ├── DownloadMultipleFilesRequest.cs
│   │   ├── DownloadMultipleFilesResponse.cs
│   │   ├── UploadFileRequest.cs
│   │   ├── UploadFileResponse.cs
│   │   ├── UploadMultipleFilesRequest.cs
│   │   └── UploadMultipleFilesResponse.cs
│   ├── Utils/
│   │   └── Utilidades.cs                               # Métodos auxiliares
│   ├── Log/                                           # Archivos de log (NLog, etc.)
│   └── Uploads/                                       # Carpeta de archivos subidos
```

## 🧠 Funcionamiento
La API Rest funciona con una serie de endpoints donde podremos subir y bajar ficheros, pero sólo de tipo Json. Además, se ha incorporado un login con una base de datos en la nube compartido con la app Android. Para simular un entorno profesional, la autenticación para usar la API se realiza con JWT (Json Web Token). Este token se le proporciona al usuario autenticado tanto en la app Android como en la API Rest y es válido mientras dure la sesión.

Durante dicha sesión, podremos descargar de nuestra API los ficheros de productos correspondientes a nuestra empresa, ya que cada email de usuario para el login tiene un único código de empresa en la base de datos. De este modo, dependiendo del email del usuario que se autentique, se bajarán y subirán sólo los ficheros correspondientes a su empresa. 

Una vez que el usuario ha terminado de usar la App Android y ha finalizado el conteo o actualización de stock de sus productos, se sube un fichero a la API Rest actualizando las unidades de los productos que haya registrado. De esta forma, se automatiza la actualización de stocks del inventario de cualquier empresa registrada. 

## Ubicación y alcance de la API
La API Rest de momento funciona en un entorno local y simula un entorno similar al empresarial, donde tendríamos decenas o cientos de empresas registradas en nuestra base de datos. A cada una de estas empresas se le gestiona el inventario, conteo y cambios en el stock de su catálogo de productos. 

Para mayor información, se puede revisar el código fuente en este mismo repositorio o visitar el vídeo explicativo del funcionamiento de la app: https://youtu.be/BRw1Nm-OryU

## 🔐 Seguridad

Las credenciales (usuario y contraseña del correo) no se hardcodean ni se suben al repositorio.
Se gestionan mediante variables de entorno tanto en nuestra máquina local (IntelliJ) como en el entorno de despliegue.

## 🎥 Vídeo explicativo en YouTube
▶️ [API Rest Inventario Móvil Empresas - Escrita en C# con .NET 9](https://www.youtube.com/watch?v=BRw1Nm-OryU)  

## 🧾 Licencia

Este proyecto se distribuye bajo licencia MIT.

## 🧑‍💻 Autor

**Rubén Nicolás Díaz**

🌐 [Portafolio](https://www.rubennicolasdiaz.me)  
💼 [LinkedIn](https://linkedin.com/in/rubennicolasdiaz)  
📫 [Email](mailto:ruben.nicolasdiaz@yahoo.com)

&copy; 2025 Rubén Nicolás Díaz
