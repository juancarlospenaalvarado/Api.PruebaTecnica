·······    Readme   ·······


* Tener instalado el sdk de .net 8 y visual studio 2022
* Tener instalado base de datos MySQl

Cambiar la cadena de conexion en el appsettings.Development.json con una cadena de conexion a su base de datos.

Restaurar los Nuget packages para e correcto funcionamiento.

Cuando se inicialice por primera vez demorara un poco mas debido a que esta creando la base de datos.


##  clone the project

```shell
git clone https://github.com/amantinband/clean-architecture
```


## Generate a token

Navigate to `requests/Tokens/GenerateToken.http` and generate a token.


```yaml
POST {{host}}/tokens/generate
Content-Type: application/json
```

```http
{
     "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "firstName": "Prueba",
    "lastName": "Prueba",
    "email": "email@gmail.com",
    "Permissions": [
        "set:emision",
        "get:emision",
        "create:emision",
		    "update:emision",
        "delete:emision"
    ],
    "Roles": [
        "Admin"
    ]
}
```
