using System;

public class Transport
{
    //число свойств
    protected const int NumberOfProperties = 7;
    //название
    public string Name { get; protected set; }
    //модель
    public string Model { get; protected set; }
    //скорость
    public double Speed { get; protected set; }
    //вес
    public double Weight { get; protected set; }
    //число мест
    public int Seats { get; protected set; }
    //мощность
    public double Capacity { get; protected set; }
    //цена
    public double Price { get; protected set; }

    public Transport(string _name, string _model, double _speed, double _weight, int _seat, double _capacity, double _price)
    {
        Name = _name;
        Model = _model;
        Speed = _speed;
        Weight = _weight;
        Seats = _seat;
        Capacity = _capacity;
        Price = _price;
    }

    public Transport(string str)
    {
        string[] DataArray = str.Split(';');
        if (DataArray.Length < NumberOfProperties)
        {
            throw new ArgumentException("Not enough arguments");
        }

        Name = DataArray[0];
        Model = DataArray[1];
        Speed = double.Parse(DataArray[2]);
        Weight = double.Parse(DataArray[3]);
        Seats = int.Parse(DataArray[4]);
        Capacity = double.Parse(DataArray[5]);
        Price = double.Parse(DataArray[6]);
    }

    public override string ToString()
    {
        return Name;
    }

    public virtual string GetAddPropertyString() { return ""; }
}
public class Car : Transport 
{
    private const int NumberOfAdditionalProperties = 1;
    //число колёс
    private int Wheels;
    public Car(string _name, string _model, double _speed, double _weight, int _seat, double _capacity, double _price, int _wheels)
        : base(_name, _model, _speed, _weight, _seat, _capacity, _price)
    {
        Wheels = _wheels;
    }

    public Car(string str) : base(str)
    {
        string[] DataArray = str.Split(';');
        if (DataArray.Length < NumberOfProperties + NumberOfAdditionalProperties)
        {
            throw new ArgumentException("Not enough arguments");
        }

        Wheels = int.Parse(DataArray[NumberOfProperties]);
    }
    public override string GetAddPropertyString()
    {
        return "Wheels "+ Wheels;
    }
}
public class Boat : Transport
{
    private const int NumberOfAdditionalProperties = 1;
    //водоизмещение
    private int Displacement;
    public Boat(string _name, string _model, double _speed, double _weight, int _seat, double _capacity, double _price, int _displacement)
         : base(_name, _model, _speed, _weight, _seat, _capacity, _price)
    {
        Displacement = _displacement;
    }

    public Boat(string str) : base(str)
    {
        string[] DataArray = str.Split(';');
        if (DataArray.Length < NumberOfProperties + NumberOfAdditionalProperties)
        {
            throw new ArgumentException("Not enough arguments");
        }

        Displacement = int.Parse(DataArray[NumberOfProperties]);
    }

    public override string GetAddPropertyString()
    {
        return "Displacement " + Displacement;
    }
}
public class Aircraft : Transport
{
    private const int NumberOfAdditionalProperties = 1;
    //максимальная высота полёта
    private int MaxHeight;
    public Aircraft(string _name, string _model, double _speed, double _weight, int _seat, double _capacity, double _price, int _maxheight)
         : base(_name, _model, _speed, _weight, _seat, _capacity, _price)
    {
        MaxHeight = _maxheight;
    }

    public Aircraft(string str) : base(str)
    {
        string[] DataArray = str.Split(';');
        if (DataArray.Length < NumberOfProperties + NumberOfAdditionalProperties)
        {
            throw new ArgumentException("Not enough arguments");
        }

        MaxHeight = int.Parse(DataArray[NumberOfProperties]);
    }
    public override string GetAddPropertyString()
    {
        return "MaxHeight "+ MaxHeight;
    }
}
public class Train : Transport
{
    private const int NumberOfAdditionalProperties = 1;
    //число вагонов
    private int Wagons;
    public Train(string _name, string _model, double _speed, double _weight, int _seat, double _capacity, double _price, int _wagons)
         : base(_name, _model, _speed, _weight, _seat, _capacity, _price)
    {
        Wagons = _wagons;
    }

    public Train(string str) : base(str)
    {
        string[] DataArray = str.Split(';');
        if (DataArray.Length < NumberOfProperties + NumberOfAdditionalProperties)
        {
            throw new ArgumentException("Not enough arguments");
        }

        Wagons = int.Parse(DataArray[NumberOfProperties]);
    }

    public override string GetAddPropertyString()
    {
        return "Wagons "+ Wagons;
    }
}


