namespace IIP2
{
	class Program
	{
		static void Main(string[] args)
		{
			var order = new WarehouseStep()
				.Step(new PaymentStep())
				.Step(new LoggerStep());
				
				string result = order.Process(1);
				Console.WriteLine(result);
				
		
			
		}
	}
}

