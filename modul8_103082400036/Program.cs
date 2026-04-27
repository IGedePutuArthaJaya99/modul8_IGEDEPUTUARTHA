using System;

namespace modul8_103082400036
{
    class Program
    {
        static void Main(string[] args)
        {
            // Inisialisasi konfigurasi
            BankTransferConfig btc = new BankTransferConfig();

            // awal
            if (btc.config.lang == "en")
            {
                Console.WriteLine("Please insert the amount of money to transfer:");
            }
            else
            {
                Console.WriteLine("Masukkan jumlah uang yang akan di-transfer:");
            }

            int nominal = Convert.ToInt32(Console.ReadLine());
            int biaya_transfer = 0;

            // Menghitung biaya transfer berdasarkan threshold
            if (nominal <= btc.config.transfer.threshold)
            {
                biaya_transfer = btc.config.transfer.low_fee;
            }
            else
            {
                biaya_transfer = btc.config.transfer.high_fee;
            }

            int total_biaya = nominal + biaya_transfer;

            //  Menampilkan total dan metode
            if (btc.config.lang == "en")
            {
                Console.WriteLine($"Transfer fee = {biaya_transfer}");
                Console.WriteLine($"Total amount = {total_biaya}");
                Console.WriteLine("Select transfer method:");
            }
            else
            {
                Console.WriteLine($"Biaya transfer = {biaya_transfer}");
                Console.WriteLine($"Total biaya = {total_biaya}");
                Console.WriteLine("Pilih metode transfer:");
            }

            // Print list method 
            for (int i = 0; i < btc.config.methods.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {btc.config.methods[i]}");
            }

            // Menerima input metode dari user
            Console.ReadLine();

            // Konfirmasi transaksi
            if (btc.config.lang == "en")
            {
                Console.WriteLine($"Please type \"{btc.config.confirmation.en}\" to confirm the transaction:");
            }
            else
            {
                Console.WriteLine($"Ketik \"{btc.config.confirmation.id}\" untuk mengkonfirmasi transaksi:");
            }

            string konfirmasi = Console.ReadLine();

            // Validasi konfirmasi
            if (btc.config.lang == "en")
            {
                if (konfirmasi == btc.config.confirmation.en)
                {
                    Console.WriteLine("The transfer is completed");
                }
                else
                {
                    Console.WriteLine("Transfer is cancelled");
                }
            }
            else
            {
                if (konfirmasi == btc.config.confirmation.id)
                {
                    Console.WriteLine("Proses transfer berhasil");
                }
                else
                {
                    Console.WriteLine("Transfer dibatalkan");
                }
            }
        }
    }
}