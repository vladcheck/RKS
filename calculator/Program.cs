using Windows.ApplicationModel.Activation;

class Calculator
{
    static void PrintLogo()
    {
        Console.WriteLine(
            """
             $$$$$$\    $$\ $$\          $$$$$$\   $$$$$$\  $$\       $$$$$$\  
            $$  __$$\   $$ \$$ \        $$  __$$\ $$  __$$\ $$ |     $$  __$$\ 
            $$ /  \__|$$$$$$$$$$\       $$ /  \__|$$ /  $$ |$$ |     $$ /  \__|
            $$ |      \_$$  $$   |      $$ |      $$$$$$$$ |$$ |     $$ |      
            $$ |      $$$$$$$$$$\       $$ |      $$  __$$ |$$ |     $$ |      
            $$ |  $$\ \_$$  $$  _|      $$ |  $$\ $$ |  $$ |$$ |     $$ |  $$\ 
            \$$$$$$  |  $$ |$$ |        \$$$$$$  |$$ |  $$ |$$$$$$$$\\$$$$$$  |
             \______/   \__|\__|         \______/ \__|  \__|\________|\______/ 
            """
        );
    }
    static void PrintOperationInstructions(bool useMemory)
    {
        Console.WriteLine(
            $"""

                Введите число для выбора операции:
                (1) Сложить два числа (*)
                (2) Вычесть два числа (-)
                (3) Умножить два числа (*)
                (4) Разделить два числа (/)
                (5) Остаток от деления (%)
                (6) 1/x
                (7) Квадрат числа
                (8) Квадратный корень из числа
                (9) Сохранить число в память (M+)
                (10) Очистить память (M-)
                (11) Использовать число из памяти как первое входное число? ({((useMemory) ? "да" : "нет")})
                (12) Посмотреть память (MR)
                (13) Показать эту инструкцию снова
                (0) ВЫЙТИ ИЗ ПРОГРАММЫ

            """
        );
    }

    static double GetNumber()
    {
        Console.Write("Введите число: ");
        double res;
        if (Double.TryParse(Console.ReadLine(), out res))
        {
            return res;
        } else
        {
            Console.Write("Ввод неверный, скорее всего, в нем была введена точка, а не запятая.");
            return 0.0;
        }
    }

    static short GetInstruction()
    {
        Console.Write("Введите номер операции: ");
        if (short.TryParse(Console.ReadLine(), out short res))
        {
            return res;
        }
        else
        {
            Console.Write("Ввод неверный, скорее всего, в нем была введена точка, а не запятая.");
            return -1;
        }
    }

    static double PerformBinaryAction(double a, double b, short instructionNumber)
    {
        return instructionNumber switch
        {
            1 => a + b,
            2 => a - b,
            3 => a * b,
            4 => a / b,
            5 => a % b,
            6 => 1 / a,
            _ => 0,
        };
    }
    
    static double PerformUnaryAction(double a, short instructionNumber)
    {
        return instructionNumber switch
        {
            6 => 1 / a,
            7 => a * a,
            8 => Math.Sqrt(a),
            _ => 0
        };
    }
    public static void Main()
    {
        const short BINARY_OPERATION_LAST_INDEX = 5;
        const short UNARY_OPERATION_LAST_INDEX = 8;
        double memory = 0;
        bool useMemory = false;

        PrintLogo();
        PrintOperationInstructions(useMemory);

        do
        {
            Console.Write("\nВведите операцию: ");
            short instructionNumber = Convert.ToInt16(Console.ReadLine());
            double result;

            if (instructionNumber == -1)
            {
                continue;
            }
            else if (instructionNumber == 0)
            {
                break;
            }
            else if (instructionNumber <= BINARY_OPERATION_LAST_INDEX)
            {
                double a = useMemory ? memory : GetNumber();
                double b = GetNumber();
                result = PerformBinaryAction(a, b, instructionNumber);
                Console.WriteLine($"Итог: {result}");
            }
            else if (instructionNumber <= UNARY_OPERATION_LAST_INDEX)
            {
                double a = useMemory ? memory : GetNumber();
                result = PerformUnaryAction(a, instructionNumber);
                Console.WriteLine($"Итог: {result}");
            }
            else
            {
                switch (instructionNumber)
                {
                    case 9:
                        double a = GetNumber();
                        memory = a;
                        break;
                    case 10:
                        memory = 0;
                        Console.WriteLine("Память сброшена.");
                        break;
                    case 11:
                        useMemory = !useMemory;
                        break;
                    case 12:
                        Console.WriteLine($"M: {memory} (память {(useMemory ? "" : "не")} используется)");
                        break;
                    case 13:
                        PrintOperationInstructions(useMemory);
                        break;
                }
            }
        } while (true);
    }
}
