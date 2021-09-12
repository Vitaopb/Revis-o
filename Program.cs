using System;

namespace Revisão
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string opcaoUser = ObterOpcaoUser();
            Aluno[] alunos = new Aluno[5];
            int indiceAluno = 0;

            while (opcaoUser.ToLower() != "x")
            {
                switch(opcaoUser)
                {
                    case "1":
                        // ADD ALUNO!
                        Console.WriteLine("INFORME O NOME DO ALUNO: ");
                        var aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("INFOME A NOTA DO ALUNO: ");
                        
                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                        aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("VALOR DA NOTA DEVE SER DECIMAL!!!");
                        }

                        alunos[indiceAluno] = aluno;
                        indiceAluno++;
                        Console.WriteLine("");
                        Console.WriteLine("ALUNO ADICIONADO!");
                        Console.WriteLine("");
                        break;
                    case "2":
                        // PRINT ALUNOS
                        foreach(var a in alunos)
                        {
                            if(!string.IsNullOrEmpty(a.Nome))
                            {
                                Console.WriteLine($"ALUNO: {a.Nome} - NOTA: {a.Nota}");
                                Console.WriteLine();
                            }
                        }
                        break;
                    case "3":
                        // CALCULATE OVERALL AVARAGE
                        decimal notaTotal = 0;
                        var nrAlunos = 0;

                        for (int i=0; i < alunos.Length; i++)
                        {
                            if(!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAlunos++;
                            }
                        }

                        var mediaTotal = notaTotal / nrAlunos;
                        Conceito conceitoGeral;
                        if(mediaTotal < 2)
                        {
                           conceitoGeral = Conceito.E;

                        }else if(mediaTotal < 4)
                        {
                           conceitoGeral = Conceito.D;

                        }else if(mediaTotal < 6)
                        {
                           conceitoGeral = Conceito.C;

                        }else if(mediaTotal < 8)
                        {
                           conceitoGeral = Conceito.B;

                        }else
                        {
                           conceitoGeral = Conceito.A;
                        }
                        Console.WriteLine($"MÉDIA GERAL: {mediaTotal} - CONCEITO: {conceitoGeral}");

                        break;
                    default:
                        throw new ArgumentOutOfRangeException("OPÇÃO NÃO EXISTE!");
                }
                    opcaoUser = ObterOpcaoUser();
            }
        }

               
        private static string ObterOpcaoUser()
        {
            Console.WriteLine();
            Console.WriteLine("INFORME A OPÇÃO DESEJADA: ");
            Console.WriteLine("1 - INSERIR UM NOVO ALUNO: ");
            Console.WriteLine("2 - LISTAR ALUNOS: ");
            Console.WriteLine("3 - CALCULAR MÉDIA GERAL: ");
            Console.WriteLine("X - SAIR");
            Console.WriteLine("-----------------------");
            Console.WriteLine();
            string opcaoUser =  Console.ReadLine();
            return opcaoUser;
        }
    }
}
