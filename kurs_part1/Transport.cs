using System;
public class Transport
{
    protected const int NumberOfProperties = 7;
    public string Name { get; protected set; }
    public string Model { get; protected set; }
    public double Speed { get; protected set; }
    public double Weight { get; protected set; }
    public int Seats { get; protected set; }
    public double Capacity { get; protected set; }
    public double Price { get; protected set; }

    public Transport(string _name, string _model, double _speed, double _mass, int _seat, double _capacity, double _price)
    {
        Name = _name;
        Model = _model;
        Speed = _speed;
        Weight = _mass;
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
    private int Wheels;
    public Car(string _name, string _model, double _speed, double _mass, int _seat, double _capacity, double _price, int _wheels)
        : base(_name, _model, _speed, _mass, _seat, _capacity, _price)
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
    private int Displacement;
    public Boat(string _name, string _model, double _speed, double _mass, int _seat, double _capacity, double _price, int _displacement)
         : base(_name, _model, _speed, _mass, _seat, _capacity, _price)
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
    private int Height;
    public Aircraft(string _name, string _model, double _speed, double _mass, int _seat, double _capacity, double _price, int _height)
         : base(_name, _model, _speed, _mass, _seat, _capacity, _price)
    {
        Height = _height;
    }

    public Aircraft(string str) : base(str)
    {
        string[] DataArray = str.Split(';');
        if (DataArray.Length < NumberOfProperties + NumberOfAdditionalProperties)
        {
            throw new ArgumentException("Not enough arguments");
        }

        Height = int.Parse(DataArray[NumberOfProperties]);
    }
    public override string GetAddPropertyString()
    {
        return "Height"+ Height;
    }
}
public class Train : Transport
{
    private const int NumberOfAdditionalProperties = 1;
    private int Wagons;
    public Train(string _name, string _model, double _speed, double _mass, int _seat, double _capacity, double _price, int _wagons)
         : base(_name, _model, _speed, _mass, _seat, _capacity, _price)
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


