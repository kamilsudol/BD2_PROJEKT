using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedType(Format.Native)]
public struct Kolo : INullable
{
    private double promien;

    private double wspolrz_x1;
    private double wspolrz_x2;

    private double wspolrz_y1;
    private double wspolrz_y2;

    public Kolo(List<double> args)
    {
        m_Null = false;

        wspolrz_x1 = args[0];
        wspolrz_y1 = args[1];
        wspolrz_x2 = args[2];
        wspolrz_y2 = args[3];

        promien = .0;

        this.WyznaczPromien();
    }

    public void WyznaczPromien()
    {
        double tmp = Math.Sqrt(Math.Pow(wspolrz_x2 - wspolrz_x1, 2) + Math.Pow(wspolrz_y2 - wspolrz_y1, 2));
        promien = tmp;
    }

    public double WyznaczObwod()
    {
        return Math.Round(2 * promien * Math.PI, 2);
    }

    public double WyznaczPole()
    {
        return Math.Round(Math.Pow(promien, 2) * Math.PI, 2);
    }

    public string Pole()
    {
        return "Pole kola: " + WyznaczPole().ToString();
    }

    public string Obwod()
    {
        return "Obwod kola: " + WyznaczObwod().ToString();
    }

    public bool Validator() {
        return this.promien != 0;
    }

    public override string ToString()
    {
        string returning_str = "Kolo o promieniu " + Math.Round(this.promien, 2).ToString()
                + " o wspolrzednych srodka (" + this.wspolrz_x1.ToString()
                + ", " + this.wspolrz_y1.ToString() + ").";
        return returning_str;
    }

    public bool IsNull
    {
        get
        {
            // Put your code here
            return m_Null;
        }
    }

    public static Kolo Null
    {
        get
        {
            Kolo h = new Kolo();
            h.m_Null = true;
            return h;
        }
    }

    public static Kolo Parse(SqlString s)
    {
        if (s.IsNull)
            return Null;
        string[] arguments = s.Value.Split("/".ToCharArray());

        if (arguments.Length != 4)
        {
            throw new ArgumentException("$Niepoprawna liczba argumentów! (wymagane 4)$");
        }

        List<double> tmp = new List<double>();

        try
        {
            foreach (var x in arguments)
            {
                tmp.Add(double.Parse(x));
            }
        }
        catch
        {
            throw new ArgumentException("$Niepoprawny typ danych!$");
        }
        Kolo u = new Kolo(tmp);
        if (u.Validator() == false) throw new ArgumentException("$Nie da sie utworzyc kola z podanych punktow!$");
        // Put your code here
        return u;
    }

    private bool m_Null;
}