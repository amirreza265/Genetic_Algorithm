namespace Core.Domain.Genetic.InitialPopulation
{
    public static class InitialPopulationGAFunctionsExtension
    {
        public static TGene[] RandomInitialPopulation<TGene>(this GAFunctions gs, Func<TGene> randomFunction, int length = 1)
        {
            var list = new List<TGene>();

            for (int i = 0; i < length; i++)
            {
                list.Add(randomFunction());
            }

            return list.ToArray();  
        }
    }
}
