
window.onload = inicializaEventos;

function inicializaEventos(){

    document.getElementById("btnHello").addEventListener("click", llamada, false);

}

function llamada() {

    //alert('Hola Mundo');
    
    var miLlamada = new XMLHttpRequest();
    //miLlamada.open("GET", "/Home/Index");
    miLlamada.open("GET", "https://apirestpersonasdylan.azurewebsites.net/api/Personas/4");

    //mientras vienen los datos
    miLlamada.onreadystatechange = function () {

        alert(miLlamada.readyState);

        if (miLlamada.readyState < 4)
        {
            document.getElementById("textoMostrar").innerHTML = "Cagrando.....";
        }
        else if (miLlamada.readyState == 4 && miLlamada.status == 200)
        {
            document.getElementById("textoMostrar").innerHTML = miLlamada.responseText;
        }
    }

    miLlamada.send();

}