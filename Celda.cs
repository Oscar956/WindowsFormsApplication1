using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

class Celda
{
    public enum Estado { viva, muerta };
    int x, y;
    public Estado estado_actual;
    public Estado estado_siguiente;
    static int lado = 20;



    public Celda(int x, int y, Random r)
    {

        double d = r.NextDouble();
        if (d < .90)
            estado_actual = Estado.muerta;
        else
            estado_siguiente = Estado.viva;

        this.x = x; this.y = y;


    }

    public void Dibuja(Form f)
    {

        Graphics g = f.CreateGraphics();
        g.DrawRectangle(new Pen(Color.Black, 1), x, y, lado, lado);
        if (estado_actual == Estado.viva)
            g.FillEllipse(new SolidBrush(Color.Red), x, y, lado, lado);

    }

    public void update()
    {
        estado_actual = estado_siguiente;
    }

}

class Tablero
{
    List<List<Celda>> tablero;
    int largo, ancho;
    Random r = new Random();

    public Tablero(int ancho, int largo)
    {
        tablero = new List<List<Celda>>();
        this.largo = largo;
        this.ancho = ancho;
        for (int i = 0; i < largo; i++)
        {
            List<Celda> temp = new List<Celda>();
            for (int j = 0; j < ancho; j++)
            {
                temp.Add(new Celda(250 + i * 20, 50 + j * 20, r));
            }
            tablero.Add(temp);

        }

    }

    public void Dibuja(Form f)
    {

        for (int i = 0; i < largo; i++)
            for (int j = 0; j < ancho; j++)
            {
                tablero[i][j].Dibuja(f);
            }
    }

    public void next()
    {
        for (int i = 0; i < largo; i++)
            for (int j = 0; j < ancho; j++)
            {
                int vecinas = cuantas_vacinas_vivas(i, j);
                // Cualquier celda viva con menos de dos vecinos vivos muere , como aquellas producidas por la población comprensión .
                if (vecinas < 2)
                    tablero[i][j].estado_siguiente = Celda.Estado.muerta;
                //Cualquier celda viva
                if (tablero[i][j].estado_actual == Celda.Estado.viva)
                {
                    //Con dos o tres vecinos se crea una vida en la siguiente generación.
                    if (vecinas == 2 || vecinas == 3)
                    {

                    }

                    //Con más de tres vecinos vivos muere e igual a uno
                    else if (vecinas > 3 || vecinas == 1)
                    {
                        tablero[i][j].estado_siguiente = Celda.Estado.muerta;
                    }
                }
                //Cualquier celda muerta con exactamente tres vecinos vivos se convierte en una célula viva , como por reproducción .
                else
                {
                    if (vecinas == 3)
                    {
                        tablero[i][j].estado_siguiente = Celda.Estado.viva;


                    }
                }

            }
    }


    public void update()
    {
        for (int i = 0; i < largo; i++)
            for (int j = 0; j < ancho; j++)
                tablero[i][j].update();
    }


    int cuantas_vacinas_vivas(int i, int j)
    {
        int vivas = 0;
        //NOROESTRE
        if (i > 0 && j > 0 && tablero[i - 1][j - 1].estado_actual == Celda.Estado.viva)
            vivas++;
        //NORTE
        if (i > 0 && tablero[i - 1][j].estado_actual == Celda.Estado.viva)
            vivas++;
        //NORESTE
        if (i > 0 && j < ancho - 1 && tablero[i - 1][j + 1].estado_actual == Celda.Estado.viva)
            vivas++;
        //OESTE
        if (j > 0 && tablero[i][j - 1].estado_actual == Celda.Estado.viva)
            vivas++;
        //ESTE
        if (j < ancho - 1 && tablero[i][j + 1].estado_actual == Celda.Estado.viva)
            vivas++;
        //SUROESTE
        if (i < largo - 1 && j > 0 && tablero[i + 1][j - 1].estado_actual == Celda.Estado.viva)
            vivas++;
        //SUR
        if (i < largo - 1 && tablero[i + 1][j].estado_actual == Celda.Estado.viva)
            vivas++;
        //SURESTE
        if (i < largo - 1 && j < ancho - 1 && tablero[i + 1][j + 1].estado_actual == Celda.Estado.viva)
            vivas++;

        return vivas;

    }
}



