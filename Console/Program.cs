using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static List<DePara> ListaDepara()
        {
            return new List<DePara>()
            {
                new DePara{IdMoeda = "AFN", CodCotacao = 66},
                new DePara{IdMoeda = "ALL", CodCotacao = 49 },
                new DePara{IdMoeda = "ANG", CodCotacao = 33},
                new DePara{IdMoeda = "ARS", CodCotacao = 3 },
                new DePara{IdMoeda = "AWG", CodCotacao = 6},
                new DePara{IdMoeda = "BOB", CodCotacao = 56 },
                new DePara{IdMoeda = "BYN", CodCotacao = 64},
                new DePara{IdMoeda = "CAD", CodCotacao = 25 },
                new DePara{IdMoeda = "CDF", CodCotacao = 58},
                new DePara{IdMoeda = "CLP", CodCotacao = 16 },
                new DePara{IdMoeda = "COP", CodCotacao = 37},
                new DePara{IdMoeda = "CRC", CodCotacao = 52 },
                new DePara{IdMoeda = "CUP", CodCotacao =  8},
                new DePara{IdMoeda = "CVE", CodCotacao =  51 },
                new DePara{IdMoeda = "CZK", CodCotacao =  29},
                new DePara{IdMoeda = "DJF", CodCotacao =  36 },
                new DePara{IdMoeda = "DZD", CodCotacao =  54},
                new DePara{IdMoeda = "EGP", CodCotacao =  12 },
                new DePara{IdMoeda = "EUR", CodCotacao =  20},
                new DePara{IdMoeda = "FJD", CodCotacao =  38 },
                new DePara{IdMoeda = "GBP", CodCotacao =  22},
                new DePara{IdMoeda = "GEL", CodCotacao =  48 },
                new DePara{IdMoeda = "GIP", CodCotacao =  18},
                new DePara{IdMoeda = "HTG", CodCotacao =  63 },
                new DePara{IdMoeda = "ILS", CodCotacao =  40},
                new DePara{IdMoeda = "IRR", CodCotacao =  17 },
                new DePara{IdMoeda = "ISK", CodCotacao =  11},
                new DePara{IdMoeda = "JPY", CodCotacao =  9 },
                new DePara{IdMoeda = "KES", CodCotacao =  21},
                new DePara{IdMoeda = "KMF", CodCotacao =  19 },
                new DePara{IdMoeda = "LBP", CodCotacao =  42},
                new DePara{IdMoeda = "LSL", CodCotacao =  4 },
                new DePara{IdMoeda = "MGA", CodCotacao =  35},
                new DePara{IdMoeda = "MGB", CodCotacao =  26 },
                new DePara{IdMoeda = "MMK", CodCotacao =  69},
                new DePara{IdMoeda = "MRO", CodCotacao =  53 },
                new DePara{IdMoeda = "MRU", CodCotacao =  15},
                new DePara{IdMoeda = "MUR", CodCotacao =  7 },
                new DePara{IdMoeda = "MXN", CodCotacao =  41},
                new DePara{IdMoeda = "MZN", CodCotacao =  43 },
                new DePara{IdMoeda = "NIO", CodCotacao =  23},
                new DePara{IdMoeda = "NOK", CodCotacao =  62 },
                new DePara{IdMoeda = "OMR", CodCotacao =  34},
                new DePara{IdMoeda = "PEN", CodCotacao =  45 },
                new DePara{IdMoeda = "PGK", CodCotacao =  2},
                new DePara{IdMoeda = "PHP", CodCotacao =  24 },
                new DePara{IdMoeda = "RON", CodCotacao =  5},
                new DePara{IdMoeda = "SAR", CodCotacao =  44 },
                new DePara{IdMoeda = "SBD", CodCotacao =  32},
                new DePara{IdMoeda = "SGD", CodCotacao =  70 },
                new DePara{IdMoeda = "SLL", CodCotacao =  10},
                new DePara{IdMoeda = "SOS", CodCotacao =  61 },
                new DePara{IdMoeda = "SSP", CodCotacao =  47},
                new DePara{IdMoeda = "SZL", CodCotacao =  55 },
                new DePara{IdMoeda = "THB", CodCotacao =  39},
                new DePara{IdMoeda = "TRY", CodCotacao =  13 },
                new DePara{IdMoeda = "TTD", CodCotacao =  67},
                new DePara{IdMoeda = "UGX", CodCotacao =  59 },
                new DePara{IdMoeda = "USD", CodCotacao =  1},
                new DePara{IdMoeda = "UYU", CodCotacao =  46 },
                new DePara{IdMoeda = "VES", CodCotacao =  68},
                new DePara{IdMoeda = "VUV", CodCotacao =  57 },
                new DePara{IdMoeda = "WST", CodCotacao =  28},
                new DePara{IdMoeda = "XAF", CodCotacao =  30 },
                new DePara{IdMoeda = "XAU", CodCotacao =  60},
                new DePara{IdMoeda = "XDR", CodCotacao =  27 },
                new DePara{IdMoeda = "XOF", CodCotacao =  14},
                new DePara{IdMoeda = "XPF", CodCotacao =  50 },
                new DePara{IdMoeda = "ZAR", CodCotacao =  65},
                new DePara{IdMoeda = "ZWL", CodCotacao =  31}
            };
        }

        static string DataPtBr(DateTime data)
        {
            StringBuilder sb = new StringBuilder(data.Day.ToString().Length == 1 ? $"0{data.Day}/" : $"{data.Day}/");
            sb.Append(data.Month.ToString().Length == 1 ? $"0{data.Month}/" : $"{data.Month}/");
            sb.Append($"{data.Year}");
            return Convert.ToString(sb);
        }

        static async Task Executar()
        {
            DateTime dataInicial = DateTime.Now;
            Console.WriteLine($"Processamento iniciado em {dataInicial.ToShortDateString()} às {dataInicial.ToShortTimeString()}");
            try
            {
                HttpResponseMessage h = await new HttpClient().GetAsync("http://localhost:28044/moeda/getitemfila");
                if (!h.IsSuccessStatusCode) throw new Exception(h.ReasonPhrase);
                Moeda m = JsonConvert.DeserializeObject<Moeda>(await h.Content.ReadAsStringAsync());
                DateTime dataIni = Convert.ToDateTime(m.data_inicio);
                DateTime dataFim = Convert.ToDateTime(m.data_fim);                
                if (string.IsNullOrEmpty(m.moeda)) throw new Exception("Nenhum objeto retornado");
                List<DadosMoeda> listaDadosMoeda = new List<DadosMoeda>();
                List<DadosCotacao> listaDadosCotacao = new List<DadosCotacao>();
                List<DePara> listaDepara = ListaDepara();//carrega a lista de-para, para obter o cod_cotacao da moeda
                int codCotacao = listaDepara.Where(d => d.IdMoeda.ToUpper() == m.moeda.ToUpper()).Select(d => d.CodCotacao).FirstOrDefault();
                StreamReader sr = new StreamReader("DadosMoeda.csv");//lendo e coletando dados no DadosMoeda.csv
                string r;
                while ((r = sr.ReadLine()) != null)
                {//faz a leitura do csv, até encontrar o objeto correspondente ao que foi trazido pela API
                    string[] c = r.Split(';');
                    if (c[0].ToUpper() == m.moeda.ToUpper())
                    {//encontrou o objeto
                        DateTime dataRef = Convert.ToDateTime(c[1]);
                        if(dataRef >= dataIni && dataRef <= dataFim)
                        {
                            listaDadosMoeda.Add(new DadosMoeda { IdMoeda = c[0], DataRef = dataRef,CodCotacao = codCotacao });
                        }
                    }
                }
                sr.Close();                
                if (listaDadosMoeda.Count == 0) throw new Exception("Não foi encontrada nenhuma ocorrência do objeto trazido pela API no arquivo DadosMoeda.csv");
                sr = new StreamReader("DadosCotacao.csv");//lendo e coletando dados no DadosCotacao.csv
                r = null;
                while ((r = sr.ReadLine()) != null)
                {
                    string[] c = r.Split(';');
                    if (c[0].ToLower() != "vlr_cotacao" && Convert.ToInt32(c[1]) == codCotacao)
                    {
                        listaDadosCotacao.Add(new DadosCotacao { CodCotacao = codCotacao, VlrCotacao = Convert.ToDecimal(c[0]), DataCotacao = Convert.ToDateTime(c[2]) });
                    }
                }
                sr.Close();
                if (listaDadosCotacao.Count == 0) throw new Exception($"Não foi encontrado nenhum dado de cotação para a moeda {m.moeda}");
                StringBuilder sb = new StringBuilder("ID_MOEDA;DATA_REF;VL_COTACAO\n");//para armazenar informações de DadosMoeda, para gerar o arquivo
                foreach(DadosMoeda dm in listaDadosMoeda)
                {
                    dm.VlCotacao = listaDadosCotacao.Where(c => c.DataCotacao == dm.DataRef).Select(c => c.VlrCotacao).FirstOrDefault(); 
                    sb.Append($"{dm.IdMoeda};{DataPtBr(dm.DataRef)};{dm.VlCotacao}\n");
                }
                //gerando o arquivo com o resultado
                string nomeArquivo = $"Resultado_{DateTime.Now.Year}";
                nomeArquivo = DateTime.Now.Month.ToString().Length == 1 ? $"{nomeArquivo}0{DateTime.Now.Month}" : $"{nomeArquivo}{DateTime.Now.Month}";
                nomeArquivo = DateTime.Now.Day.ToString().Length == 1 ? $"{nomeArquivo}0{DateTime.Now.Day}_" : $"{nomeArquivo}{DateTime.Now.Day}_";
                nomeArquivo = DateTime.Now.Hour.ToString().Length == 1 ? $"{nomeArquivo}0{DateTime.Now.Hour}" : $"{nomeArquivo}{DateTime.Now.Hour}";
                nomeArquivo = DateTime.Now.Minute.ToString().Length == 1 ? $"{nomeArquivo}0{DateTime.Now.Minute}" : $"{nomeArquivo}{DateTime.Now.Minute}";
                nomeArquivo = DateTime.Now.Second.ToString().Length == 1 ? $"{nomeArquivo}0{DateTime.Now.Second}.csv" : $"{nomeArquivo}{DateTime.Now.Second}.csv";
                StreamWriter sw = new StreamWriter(nomeArquivo);
                sw.Write(Convert.ToString(sb));
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine($"Processamento finalizado em {DateTime.Now.ToShortDateString()} as {DateTime.Now.ToShortTimeString()}");
                Console.WriteLine($"Tempo de processamento: {DateTime.Now.Subtract(dataInicial).TotalSeconds} segundos.\n");
                Console.WriteLine($"Aguardando novo processo...\n");
                System.Threading.Thread.Sleep(120000);//pausa de 2 minutos
                await Executar();//repete a chamada do método, as cada 2 minutos, enquanto a aplicação estiver sendo executada
            }
        }

        static async Task Main()
        {
            await Executar();
        }
    }
}