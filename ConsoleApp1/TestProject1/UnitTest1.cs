// using APBDPROLEON;
//
// namespace TestProject1;
//
// public class UnitTest
// {
//     [Fact]
//     public void CheckAdd()
//     {
//         var personalComputer = new PersonalComputer("P001", "MyPC", true, "Windows 10");
//         DeviceManagerMainOperations deviceManagerMainOperations = new DeviceManagerMainOperations("anypath.txt");
//         deviceManagerMainOperations.AddDevice(personalComputer);
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
// //two unit test still to work on
// //     [Fact]
// //     public void CheckEdit()
// //     {
// //         var personalComputer1 = new PersonalComputer("P001", "MyPC", true, "Windows 10");
// //         DeviceManager deviceManager = new DeviceManager("abcdpath.txt");
// //         deviceManager.AddDevice(personalComputer1);
// //         
// //         var devices = deviceManager.GetDevices();
// //         Assert.Equal(1, devices.Count);
// //         Assert.Equal("P001", devices[0].Id);
// //         
// //         deviceManager.EditDevice("P001","Widnows 11");
// //         
// //         var edited = deviceManager.GetDevices();
// //         Assert.Equal("Windows 11", edited[0],OperatingSystem);
// //     }
// // }
//     // [Fact]
//     // //mistake somewhere still have to wrok on that
//     // public void CheckShowDevices()
//     // {
//     //     DeviceManager deviceManager = new DeviceManager("abcdpath.txt");
//     //
//     //     var personalComputer1 = new PersonalComputer("P001", "MyPC", true, "Windows 10");
//     //     var smartWatch1 = new SmartWatch("SW001", "MySmartWatch", true, 75);
//     //
//     //     deviceManager.AddDevice(personalComputer1);
//     //     deviceManager.AddDevice(smartWatch1);
//     //
//     //     Assert.Equal("MyPC", personalComputer1.Id);
//     //     Assert.Equal("MySmartWatch", smartWatch1.Id);
//     // }
//
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
//     public void CheckSaveFile()
//     {
//         string testFilePath = "test_output.txt";
//         File.Delete(testFilePath);
//         
//         var manager = new DeviceManagerMainOperations(testFilePath);
//         
//         var personalComputer1 = new PersonalComputer("P001", "MyPC", true, "Windows 10");
//         
//         manager.AddDevice(personalComputer1);
//         
//         manager.SaveToFile();
//         
//         string[] lines = File.ReadAllLines(testFilePath);
//         
//         Assert.Equal("ID: P001, Name: MyPC, IsTurnedOn: True, OperatingSystem: Windows 10", lines[0]);
//         File.Delete(testFilePath);
//     }
// }
