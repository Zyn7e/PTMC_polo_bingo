Console.Title = "Polobingo - Nahuel Avila";

int[,] carton = new int[3, 9];
int[] mins_column = new int[9] { 1, 10, 20, 30, 40, 50, 60, 70, 80 }, max_column = new int[9] { 10, 20, 30, 40, 50, 60, 70, 80, 91 };

int contador;

Random generator = new Random();

//Generar cartón lleno de npumeros.
for (int iColumn = 0; iColumn < 9; iColumn++) for (int iRow = 0; iRow < 3; iRow++) carton[iRow, iColumn] = generator.Next(mins_column[iColumn], max_column[iColumn]);


//Evitar repetición de números.
int row_foreach1 = 0, column_foreach1 = 0, row_foreach2 = 0, column_foreach2 = 0;

foreach (int numero in carton)
{
    foreach (int numero2 in carton)
    {
        if (row_foreach2 == 3) row_foreach2 = 0;

        bool filas_coinciden = row_foreach1 == row_foreach2, columnas_coinciden = column_foreach1 == column_foreach2;

        if (!filas_coinciden || !columnas_coinciden)
        {
            int numero_a_comparar = numero2;

            while (numero == numero_a_comparar) numero_a_comparar = generator.Next(mins_column[column_foreach2], max_column[column_foreach2]);

            carton[row_foreach2, column_foreach2] = numero_a_comparar;
        }

        if (column_foreach2 == 8)
        {
            column_foreach2 = 0; row_foreach2++;
        }
        else column_foreach2++;
    }

    if (column_foreach1 == 8)
    {
        column_foreach1 = 0; row_foreach1++;
    }
    else column_foreach1++;
}


//Generar espacios vacios
int random_column, fila = 0, contador_de_ceros;

for (var i = 0; i < 8; i++)
{
    do
    {
        random_column = generator.Next(0, 9);

        //Compruebo cuantos ceros hay en la columna random.
        contador_de_ceros = 0;
        for (int iRow = 0; iRow < 3; iRow++) if (carton[iRow, random_column] == 0) contador_de_ceros++;

        if (contador_de_ceros == 0) carton[fila, random_column] = 0;
    }
    while (contador_de_ceros != 0);

    if (i == 3) fila++;
}

for (int iColumn = 0; iColumn < 9; iColumn++) //Bucle para rellenar buscar y generar un espacio en blanco en la columna que no haya espacios en blanco.
{
    //Compruebo cuantos ceros hay en la columna iterada.
    contador_de_ceros = 0;
    for (int iRow = 0; iRow < 3; iRow++) if (carton[iRow, iColumn] == 0) contador_de_ceros++;

    if (contador_de_ceros == 0)
    {
        carton[2, iColumn] = 0;
        break;
    }
}

contador = 1;
while (contador <= 3) //Rellena los 3 espacios en blanco que faltan en la fila 3.
{
    random_column = generator.Next(0, 9);

    //Compruebo cuantos ceros hay en la columna random.
    contador_de_ceros = 0;
    for (int iRow = 0; iRow < 3; iRow++) if (carton[iRow, random_column] == 0) contador_de_ceros++;

    if (contador_de_ceros == 1 && carton[2, random_column] != 0)
    {
        carton[2, random_column] = 0;
        contador++;
    }
}

//Impresion:
contador = 0;
foreach (var item in carton)
{
    if (item == 0) Console.Write("|██");
    else if (item < 10) Console.Write($"|0{item}");
    else Console.Write($"|{item}");

    contador++;

    if (contador == 9) { Console.Write("|\n"); contador = 0; }
}