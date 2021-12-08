using System;

public class day3{
    public static void Main(){
        List <string> data = new List <string>();
        List <string> data2 = new List <string>();
        StreamReader sr = new StreamReader("day3.txt");
        string oneline = "";

        while((oneline = sr.ReadLine()) != null){
            data.Add(oneline);
            data2.Add(oneline);
            
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
        Console.WriteLine("Part2: " + Part2(data, data2));
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
    public static int Part2( List<string> datas, List<string> datas2){
        int ones = 0;
        Console.WriteLine(datas.Count);
        Console.WriteLine(datas2.Count);
        
        //oxygen generator(more bits)
        for(int i = 0; i < 12;i++){ //oszlopok száma
            for(int j = 0; j < datas.Count; j++){ //sorok száma
                if(datas[j][i] == '1'){
                    ones++;
                }
            }
            Console.WriteLine(datas.Count + ":\t" + ones );
            
            if(ones >= (datas.Count/2)){
                for(int j = datas.Count-1; j > -1; j--){
                    
                    if(datas[j][i] == '0'){
                        datas.RemoveAt(j);
                    }
                }
            }else{
                for(int j = datas.Count-1; j > -1; j--){
                    
                    if(datas[j][i] == '1'){
                        datas.RemoveAt(j);
                    }
                }
            }
            
            ones = 0;
            
            if(datas.Count == 1){break;}
        }

        //CO2 (lower bits)
        Console.WriteLine("\nCO2 (" + datas2.Count + ")");
        for(int i = 0; i < 12;i++){ //oszlopok száma
            for(int j = 0; j < datas2.Count; j++){ //sorok száma
                if(datas2[j][i] == '1'){
                    ones++;
                }
            }
            Console.WriteLine(datas2.Count + ":\t" + ones + "(oszlop: " + (i+1) + ")");
            
            if(ones >= (datas2.Count/2)){
                for(int j = datas2.Count-1; j >= 0; j--){
                    Console.Write(datas2[j]);
                    if(datas2[j][i] == '1'){
                        datas2.RemoveAt(j);
                        Console.Write(" rm");
                    }
                    Console.WriteLine();
                }
            }else{
                for(int j = datas2.Count-1; j >= 0; j--){
                    Console.Write(datas2[j]);
                    if(datas2[j][i] == '0'){
                        datas2.RemoveAt(j);
                        Console.Write(" rm");
                    }
                     Console.WriteLine();
                }
            }
            ones = 0;
            if(datas2.Count == 1){break;}
        }
       return GetDecimal(datas2[0]) * GetDecimal(datas[0]);
    }

    public static int GetDecimal(string binaryNumber){
        return Convert.ToInt32(binaryNumber, 2);
    }
}