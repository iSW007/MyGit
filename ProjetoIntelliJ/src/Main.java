import java.io.*;
import java.util.Scanner;

public class Main {

    final static int MAX_SIZE=25;

    public static void main(String[]args) {
        try{
            System.out.println(add(readInputFromFile("input.txt")));
        }catch (FileNotFoundException f){
            f.getMessage();
        }catch (IOException e){
            e.getMessage();
        }
    }

    private static int[] readInputFromFile(String filename)throws IOException {
        File file=new File(filename);
        Scanner in=new Scanner(file);
        int[] array=new int[MAX_SIZE];
        int i=0;

        while(in.hasNextInt()){
            int x=in.nextInt();
            array[i++]=x;
        }
        return array;
    }

    private static int add(int[]a){
        int sum=0;
        for(int i=0;i<a.length;++i) {
            sum += a[i];
        }
        return sum;
    }
}
