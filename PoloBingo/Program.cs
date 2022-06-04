//NOTA: HE LOGRADO DISMINUIR LAS POSIBILIDADES DE QUE SE REPITAN NÚMEROS, ESTOY TRABAJANDO 
//EN LOGRAR ESE PUNTO AL 100% PERO DIRIA QUE EL CARTON TIENE
//SOLO UN 0,99% DE POSIBILIDADES DE QUE SE REPITAN NÚMEROS :C
//SI LOGRO MEJORARLO ANTES DE LA FECHA DE ENTREGA VUELVO A ENVIARLO. SALUDOS!!!

Console.Title = "Polobingo - Nahuel Avila";

int[,] carton = new int[3, 9];

int contador;

Random generator = new Random();



for (int iColumn = 0; iColumn < 9; iColumn++)
{

    for (int iRow = 0; iRow < 3; iRow++)
    {

        switch (iColumn)
        {
            
            case 0:
                carton[iRow, iColumn] = generator.Next(1, 10);
                break;
            case 1:
                carton[iRow, iColumn] = generator.Next(10, 20);
                break;
            case 2:
                carton[iRow, iColumn] = generator.Next(20, 30);
                break;
            case 3:
                carton[iRow, iColumn] = generator.Next(30, 40);
                break;
            case 4:
                carton[iRow, iColumn] = generator.Next(40, 50);
                break;
            case 5:
                carton[iRow, iColumn] = generator.Next(50, 60);
                break;
            case 6:
                carton[iRow, iColumn] = generator.Next(60, 70);
                break;
            case 7:
                carton[iRow, iColumn] = generator.Next(70, 80);
                break;
            case 8:
                carton[iRow, iColumn] = generator.Next(80, 91);
                break;
            default:
                break;

        }

    }

}

int row_foreach1 = 0, column_foreach1 = 0, row_foreach2 = 0, column_foreach2 = 0;

foreach (int numero in carton)
{
    foreach (int numero_a_comparar in carton)
    {
        if (row_foreach2 == 3) row_foreach2 = 0;

        bool filas_coinciden = row_foreach1 == row_foreach2, columnas_coinciden = column_foreach1 == column_foreach2;

        if (!filas_coinciden || !columnas_coinciden)
        {
            if (numero == numero_a_comparar)
            {
                switch (column_foreach1)
                {
                    case 0:
                        carton[row_foreach2, column_foreach2] = generator.Next(1, 10);
                        break;
                    case 1:
                        carton[row_foreach2, column_foreach2] = generator.Next(10, 20);
                        break;
                    case 2:
                        carton[row_foreach2, column_foreach2] = generator.Next(20, 30);
                        break;
                    case 3:
                        carton[row_foreach2, column_foreach2] = generator.Next(30, 40);
                        break;
                    case 4:
                        carton[row_foreach2, column_foreach2] = generator.Next(40, 50);
                        break;
                    case 5:
                        carton[row_foreach2, column_foreach2] = generator.Next(50, 60);
                        break;
                    case 6:
                        carton[row_foreach2, column_foreach2] = generator.Next(60, 70);
                        break;
                    case 7:
                        carton[row_foreach2, column_foreach2] = generator.Next(70, 80);
                        break;
                    case 8:
                        carton[row_foreach2, column_foreach2] = generator.Next(80, 91);
                        break;
                    default:
                        break;
                }
            }
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

    


//Espacios vacios
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

for (int iColumn = 0; iColumn < 9; iColumn++)
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
while (contador <= 3)
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
    switch (item)
    {
        case 0:
            Console.Write("|██");
            break;
        case <10:
            Console.Write($"|0{item}");
            break;
        default:
            Console.Write($"|{item}");
            break;
    }
    
    contador++;

    if (contador == 9) 
    {
        Console.Write("|\n"); contador = 0;
    }
}
