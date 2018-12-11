
window.onload = inicializaEventos;

function inicializaEventos(){

    document.getElementById("btnHello").addEventListener("click", llamada, false);

}

function llamada() {

    //alert('Hola Mundo');
    
    var miLlamada = new XMLHttpRequest();
    //miLlamada.open("GET", "/Home/Index");
    miLlamada.open("GET", "https://apirestpersonasdylan.azurewebsites.net/api/Personas/");

    //mientras vienen los datos
    miLlamada.onreadystatechange = function () {

        alert(miLlamada.readyState);

        if (miLlamada.readyState < 4)
        {
            document.getElementById("textoMostrar").innerHTML = "Cagrando.....";
        }
        else if (miLlamada.readyState == 4 && miLlamada.status == 200)
        {
            var oPersona = new Persona();

            var arrayPersonas = JSON.parse(miLlamada.responseText);

            oPersona = arrayPersonas[0];
            //document.getElementById("textoMostrar").innerHTML = miLlamada.responseText;
            document.getElementById("textoMostrar").innerHTML = oPersona.nombre;
        }
    }
    miLlamada.send();
}

class Persona {
    constructor(nombre, apellidos, fechaNacimiento) {
        this.nombre = nombre;
        this.apellidos = apellidos;
        this.fechaNacimiento = fechaNacimiento;
    }
}