using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Microsoft.Extensions.Configuration;

public static class KernelExtensions
{
	public static Kernel CreateOpenAIKernel(IConfiguration configuration)
	{
		var openAiApiKey = configuration["OpenAI:ApiKey"];
		var model = configuration["OpenAI:Model"];

		var kernel = new Kernel();

		var openAIChatCompletion = new OpenAIChatCompletionService(
			model,
			openAiApiKey
		);

		kernel.AddChatCompletionService(openAIChatCompletion);

		return kernel;
	}
}
