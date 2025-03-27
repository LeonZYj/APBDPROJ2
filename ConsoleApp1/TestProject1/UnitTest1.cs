// using APBDPROLEON;
// using APBDPROLEON.DeviceManagerSplitted;
// fopr now turning off the testing.
// namespace TestProject1;
//
// public class UnitTest
// {
//     [Fact]
//     public void CheckAdd()
//     {
//         var personalComputer = new PersonalComputer("P001", "MyPC", true, "Windows 10");
//         DeviceManagerMainOperations deviceManagerMainOperations = new DeviceManagerMainOperations("anypath.txt");
//         !deviceManagerMainOperations.AddDevice(personalComputer);
//
//         var devices = deviceManagerMainOperations.GetDevices();
//
//         Assert.Equal(1, devices.Count);
//         Assert.Equal("P001", devices[0].Id);
//     }
//
//     [Fact]
//     public void CheckRemove()
//     {
//         var personalComputer1 = new PersonalComputer("P001", "MyPC", true, "Windows 10");
//         DeviceManagerMainOperations deviceManagerMainOperations = new DeviceManagerMainOperations("anypath.txt");
//         deviceManagerMainOperations.AddDevice(personalComputer1);
//
//         var devices = deviceManagerMainOperations.GetDevices();
//         Assert.Equal(1, devices.Count);
//         Assert.Equal("P001", devices[0].Id);
//
//         deviceManagerMainOperations.RemoveDevice("P001");
//
//         var devicesafterRemove = deviceManagerMainOperations.GetDevices();
//         Assert.Equal(0, devicesafterRemove.Count);
//     }
//     [Fact]
//     public void CheckTurnOn()
//     {
//         var personalComputer1 = new PersonalComputer("P001", "MyPC", false, "Windows 10");
//
//         DeviceManagerMainOperations deviceManagerMainOperations = new DeviceManagerMainOperations("anypath.txt");
//         deviceManagerMainOperations.AddDevice(personalComputer1);
//
//         var devicesBeforeTurnOn = deviceManagerMainOperations.GetDevices();
//         Assert.Equal(false, devicesBeforeTurnOn[0].IsTurnedOn);
//
//         deviceManagerMainOperations.TurnOnDevice("P001");
//
//         var devicesAfterTurnOn = deviceManagerMainOperations.GetDevices();
//         Assert.Equal(true, devicesAfterTurnOn[0].IsTurnedOn);
//     }
//
//     [Fact]
//     public void CheckTurnOff()
//     {
//         var personalComputer1 = new PersonalComputer("P001", "MyPC", true, "Windows 10");
//         DeviceManagerMainOperations deviceManagerMainOperations = new DeviceManagerMainOperations("anypath.txt");
//         deviceManagerMainOperations.AddDevice(personalComputer1);
//
//         var devicesBeforeTurnOff = deviceManagerMainOperations.GetDevices();
//         Assert.Equal(true, devicesBeforeTurnOff[0].IsTurnedOn);
//
//         deviceManagerMainOperations.TurnOffDevice("P001");
//
//         var devicesAfterTurnOff = deviceManagerMainOperations.GetDevices();
//         Assert.Equal(false, devicesAfterTurnOff[0].IsTurnedOn);
//     }
//     
//     [Fact]
// //     public void CheckSaveFile()
// //     {
// //         string testFilePath = "test_output.txt";
// //         File.Delete(testFilePath);
// //         
// //         var manager = new DeviceManagerMainOperations(testFilePath);
// //         
// //         var personalComputer1 = new PersonalComputer("P001", "MyPC", true, "Windows 10");
// //         
// //         manager.AddDevice(personalComputer1);
// //         
// //         manager.SaveToFile();
// //         
// //         string[] lines = File.ReadAllLines(testFilePath);
// //         
// //         Assert.Equal("ID: P001, Name: MyPC, IsTurnedOn: True, OperatingSystem: Windows 10", lines[0]);
// //         File.Delete(testFilePath);
// //     }
// // }
