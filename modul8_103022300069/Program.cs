using System;
using modul8_103022300069;

class Program
{
    static void Main(string[] args)
    {
        BankTransferConfig config = new BankTransferConfig();

        Console.WriteLine($"Lang (1. En, 2. Id): ");
        string ubah = Console.ReadLine();
        if( ubah.ToLower() == "1")
        {
            config.ubahBahasa();
            Console.WriteLine($"lang {config.lang}");
        }

        if( config.lang == "en")
        {
            Console.WriteLine("Please insert the amount of money to transfer:");
            String inpMoney = Console.ReadLine();
            double money = double.Parse(inpMoney);
            
            if(money <= config.transfer.treshold)
            {
                config.transfer.treshold = config.transfer.low_fee;
            } else
            {
                config.transfer.treshold = config.transfer.high_fee;
            }

            Console.WriteLine($"Transfer fee = {config.transfer.treshold}");
            Console.WriteLine($"Total amount = {money + config.transfer.treshold}");

            Console.WriteLine("");
            for( int i = 0; i < 3; i++)
            {
                Console.WriteLine($"{i+1} {config.methods[i]}");
            }
            Console.WriteLine("Select transfer method: ");
            string inpMethod = Console.ReadLine();

            Console.WriteLine($"Please type '{config.confirmation.en}' to confirm the transaction: ");
            string inpConfirm = Console.ReadLine();
            if (config.confirmation.en == inpConfirm)
            {
                Console.WriteLine("The transfer is completed");
            }
            else {
                Console.WriteLine("Transfer is cancelled");
            }
        } else
        {
            Console.WriteLine("Masukkan jumlah uang yang akan di-transfer:");
            String inpMoney = Console.ReadLine();
            double money = double.Parse(inpMoney);

            if (money <= config.transfer.treshold)
            {
                config.transfer.treshold = config.transfer.low_fee;
            }
            else
            {
                config.transfer.treshold = config.transfer.high_fee;
            }

            Console.WriteLine($"Biaya transfer = {config.transfer.treshold}");
            Console.WriteLine($"Total biaya = {money + config.transfer.treshold}");

            Console.WriteLine("");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"{i + 1} {config.methods[i]}");
            }
            Console.WriteLine("Pilih metode transfer: ");
            string inpMethod = Console.ReadLine();

            Console.WriteLine($"Ketik '{config.confirmation.en}' untuk mengkonfirmasi transaksi: ");
            string inpConfirm = Console.ReadLine();
            if (config.confirmation.en == inpConfirm)
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