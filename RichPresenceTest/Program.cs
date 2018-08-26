using System;

namespace RichPresenceTest {
	class Program {
		private static readonly string applicationId = "444517509148966923";
		private static DiscordRpc.EventHandlers handlers;

		public static void Main(string[] args) {
			Console.WriteLine("Discord: init");
			handlers = new DiscordRpc.EventHandlers {
				readyCallback = ReadyCallback,
				disconnectedCallback = DisconnectedCallback,
				errorCallback = ErrorCallback,
				joinCallback = JoinCallback,
				spectateCallback = SpectateCallback,
				requestCallback = RequestCallback
			};
			DiscordRpc.Initialize(applicationId, ref handlers, false, null);
			while (true)
				DiscordRpc.RunCallbacks();
		}

		public static void ReadyCallback(ref DiscordRpc.DiscordUser user) {
			Console.WriteLine("Discord: connected to {0}#{1}: {2}", user.username, user.discriminator, user.userId);
		}

		public static void DisconnectedCallback(int errorCode, string message) {
			Console.WriteLine("Discord: disconnect {0}: {1}", errorCode, message);
		}

		public static void ErrorCallback(int errorCode, string message) {
			Console.WriteLine("Discord: error {0}: {1}", errorCode, message);
		}

		public static void JoinCallback(string secret) {
			Console.WriteLine("Discord: join ({0})", secret);
		}

		public static void SpectateCallback(string secret) {
			Console.WriteLine("Discord: spectate ({0})", secret);
		}

		public static void RequestCallback(ref DiscordRpc.DiscordUser user) {
			Console.WriteLine("Discord: join request {0}#{1}: {2}", user.username, user.discriminator, user.userId);
		}
	}
}
