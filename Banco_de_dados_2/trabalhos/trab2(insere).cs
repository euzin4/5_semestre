using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace TraBanco
{
    class TraBanco
    {
        public static void Main(string[] args)
        {
			//cria conexão com o banco
            SqlConnection conn = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; Initial Catalog = dbtrabanco; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
			
			//cria objeto comando associado com a conexao
            SqlCommand cmd1 = conn.CreateCommand();
            SqlCommand cmd2 = conn.CreateCommand();
			
			//seta os comandos de texto ao objeto
            cmd1.CommandText = "insert into cliente values (100, 777125, 'Testando comando 1')";
            cmd2.CommandText = "insert into cliente values (101, 777122, 'Testando comando 2')";
			
			//conecta com o banco
            conn.Open();
			
			//cria e comeca transação para a conexao conn, abrindo um bloco de comandos a serem adicionados em seguida
            SqlTransaction tran = conn.BeginTransaction();

            try
            {
				//ligacao do comando ao objeto de transação
                cmd1.Transaction = tran;
				
				//executa o comando de texto do insert
                cmd1.ExecuteNonQuery();
				
				//printa mensagem de sucesso
                Console.WriteLine("Comando 1 executado com sucesso!");
                
                cmd2.Transaction = tran;
				
                cmd2.ExecuteNonQuery();
				
                Console.WriteLine("Comando 2 executado com sucesso!");
				
				//faz o commit que efetiva a transação e insere os valores na tabela
                tran.Commit();
            }
            catch (SqlException ex)
            {
				//ocorre o rollback que cancela a transação e exibe mensagem de erro do exception
                tran.Rollback();
                Console.WriteLine(ex.Message);
            }
            finally
            {
				//desconecta do banco
                conn.Close();
            }
            Console.ReadKey();
        }
    }
}
