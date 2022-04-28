// See https://aka.ms/new-console-template for more information
using AcademyF.Week1.Demo;

Console.WriteLine("Hello, World!");

//Person p1 = new Person();
int a = 1;
int b = 2;
int c = Somma(a, b);
Console.WriteLine(c);


Console.WriteLine($"a={a}\t b={b}");
CambiaValore(ref a, b);
Console.WriteLine($"a={a}\t b={b}");

CambiaValoreESomma(a, b, out int r);
Console.WriteLine($"a={a}\t b={b}\t r={r}");

int risultato;
CambiaValoreESomma(33,44,out risultato);
Console.WriteLine(risultato);


CambiaValoreESomma(33, 44, out int risultato1);
Console.WriteLine(risultato1);

int Somma(int x,int y)
{
    return x + y;
}

void CambiaValore(ref int x,int y)
{
    x = 10;
    y = 20;
}

Console.WriteLine($"a={a}\t b={b}");
void CambiaValoreESomma(int x, int y, out int result) //out è per riferimento
{
    x = 100;
    y = 200;
    result = x + y;
}

void CambiaValore2(ref int x,in int y)
{
    x = 10;
    //y = 20; il parametro non può essere modificato perchè c'è in non fa fare una riassegnazione
}