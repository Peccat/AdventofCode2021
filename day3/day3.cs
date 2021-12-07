using System;

public class day3{
    public static void Main(){
        List <string> data = new List <string>();
        StreamReader sr = new StreamReader("day3.txt");
        string oneline = "";

        while((oneline = sr.ReadLine()) != null){
            data.Add(oneline);
        }

        int[,] BinaryArray = new int[data.Count,((data[0].ToCharArray()).Length)];
        for(int j = 0; j < data.Count; j++){
            char[] line = data[j].ToCharArray();
            for(int i = 0; i < line.Length; i++){
                BinaryArray[j,i] = line[i]-48;
                //Console.Write(BinaryArray[j,i]);
            }
            //Console.WriteLine();
        }

        
        Console.WriteLine("Part1: " + Part1(BinaryArray));
        Console.WriteLine("Part2: " + Part2(data));
    }

    public static int Part1(int[,] BinaryArray){
        

        int ones = 0;
        string gamma = "";
        string epsilon = "";

        
        for(int i = 0; i < 12; i++){
            for(int j = 0; j < 1000;j++){
                switch (BinaryArray[j,i]){
                    case 1:
                        ones ++;
                        break;
                }
                
            }
            if(ones > 500){
            gamma += "1"; epsilon +=  "0";
            }else{
            gamma += "0"; epsilon +=  "1";
            }
            ones = 0;
        }

        Console.WriteLine("gamma\t" + gamma);
        Console.WriteLine("epsilon\t" + epsilon);


        return GetDecimal(gamma) * GetDecimal(epsilon);
    }
    public static int Part2( List<string> datas){
        int ones = 0;

        for(int i = 0; i < 12;i++){ //oszlopok száma
            for(int j = 0; j < datas.Count; j++){
                if(datas[j][i] == '1'){
                    ones++;
                }
            }
            Console.WriteLine(ones);
            if(ones > datas.Count-1){
                for(int j = datas.Count-1; j >= 0; j--){
                    if(datas[j][i] == '1'){
                        datas.RemoveAt(j);
                    }
                }
            }else{
                for(int j = datas.Count-1; j >= 0; j--){
                    if(datas[j][i] == '0'){
                        datas.RemoveAt(j);
                    }
                }
            ones = 0;
            }
        }
       return datas.Count;
    }

    public static int GetDecimal(string binaryNumber){
        return Convert.ToInt32(binaryNumber, 2);
    }
}