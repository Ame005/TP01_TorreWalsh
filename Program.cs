// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using System.Linq;
Dictionary<string,double> dicAlumnosCumpleanios = new Dictionary<string, double>();
string curso="";
int topeCurso,eleccion;
double montoCurso=0,montoTotalCurso=0;
do{
    eleccion=menu();
    switch(eleccion){
        case 1:
        curso=IngresarString("Ingrese el curso");
        topeCurso=IngresarInt("Ingrese la cantidad de alumnos");
        for (int i=0;i<topeCurso;i++){
            montoCurso=IngresarInt("Ingrese su aporte");
            while(!verificarMonto(montoCurso)){
                Console.WriteLine("Monto no válido. Vuelva a ingresarlo");
                montoCurso=IngresarInt("Ingrese su aporte");
            }
            montoTotalCurso+=montoCurso;
        }
        dicAlumnosCumpleanios.Add(curso,montoTotalCurso);
        break;
        case 2:
        //fijarse si el diccionario tiene valores
        if (cantidadCursos(dicAlumnosCumpleanios)>0){
            string[] resultados=new string[4];
        resultados[0]=verMayorAporteCurso(dicAlumnosCumpleanios);
        resultados[1]=promedioPlataCursos(dicAlumnosCumpleanios);
        resultados[2]=recaudacionTotalCursos(dicAlumnosCumpleanios);
        resultados[3]=cantidadCursos(dicAlumnosCumpleanios).ToString();
        foreach (var resultado in resultados)
        {
            Console.WriteLine(resultado);
        }  
        }
        else{
            Console.WriteLine("No hay valores para analizar.");
        }
        break;
    }
    Console.ReadKey();
}while(eleccion!=0);
/*una vez que se ingresa el cursoy la cant de estudiantes se tiene 
que ingresar el monto
*/
int cantidadCursos(Dictionary<string,double> dicAlumnosCumpleanios){
    int contCursos=0;
    foreach (var curso in dicAlumnosCumpleanios.Keys)
    {
        contCursos++;   
    }
    return contCursos;
}
string recaudacionTotalCursos(Dictionary<string,double> dicAlumnosCumplanios){
    string devolver;
    double suma=0;
    foreach (var monto in dicAlumnosCumplanios.Values){
        suma+=monto;
    }
    return devolver=suma.ToString();
}
string promedioPlataCursos(Dictionary<string,double> dicAlumnosCumpleanios){
    string devolver;
    double promedio=0,suma=0,cont=0;
    foreach (var monto in dicAlumnosCumpleanios.Values)
    {
        suma+=monto;
        cont++;
    }
    promedio=suma/cont;
    return devolver=promedio.ToString();
}
string verMayorAporteCurso(Dictionary<string,double> dicAlumnosCumpleanios){
    string devolver="";
    double mayor=0;
    foreach(string montoCurso in dicAlumnosCumpleanios.Keys){
        if(dicAlumnosCumpleanios[montoCurso]>mayor){
            mayor=dicAlumnosCumpleanios[montoCurso];
            devolver=montoCurso;
        }
    }
    return devolver;
}
bool verificarMonto(double montoCurso){
    bool devolver=false;
    devolver=(montoCurso>0);
    return devolver;
}
string IngresarString (string mensaje)
{
    string devolver; 
    Console.WriteLine(mensaje); 
    devolver= Console.ReadLine();
    return devolver; 
}
int IngresarInt (string mensaje)
{
    int num; 
    Console.WriteLine(mensaje); 
    num= int.Parse(Console.ReadLine()); 
    return num; 
}
int menu(){
    int devolver;
    do{
        Console.WriteLine("1- Ingrese los importes de un curso");
        Console.WriteLine("2- Ver estadísticas");
        devolver=int.Parse(Console.ReadLine());
    }while(devolver<0||devolver>2);
    return devolver;
}