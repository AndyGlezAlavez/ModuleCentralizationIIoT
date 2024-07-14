using ModuleCentralizationIIoT.Contracts;
using ModuleCentralizationIIoT.DataAccess.Contexts;
using ModuleCentralizationIIoT.DataAccess.Repositories;
using ModuleCentralizationIIoT.DataAccess.Test.Utilities;
using ModuleCentralizationIIoT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleCentralizationIIoT.DataAccess.Test
{
    public class MessageTest
    {
        private IMessageRepository _messageRepository;
        private IUnitOfWork _unitOfWork;
        
        public MessageTest()
        {
            ApplicationContext context =  new ApplicationContext(ConnectionStringProvider.GetConnectionString());
            _messageRepository= new MessageRepository(context);
            _unitOfWork= new UnitOfWork(context);
        }
        [DataRow("Hellow World", "Modulo Zigbee", "192.168.137.5")]
        [DataRow("Bye World", "Modulo LTE", "192.156.122.1")]

        [TestMethod]
        public void Can_Add_Message(
            string text,
            string name,
            string addressIp)
        {
            //Arrange
            Guid id = Guid.NewGuid();
            Message message= new Message(text,new ModuleIIoT(name,addressIp));
            message.Id = id;

            //Execute
            _messageRepository.AdddMessage(message);
            _unitOfWork.SaveChages();

            //Assert
            Message? loadedMessage=_messageRepository.GetMessageById(id);
            Assert.IsNotNull(loadedMessage);

        }
        [DataRow(0)]
        [TestMethod]
        public void Can_Get_Message_By_Id(int position)
        {
            //Arrange
            var message = _messageRepository.GetAllMessage().ToList();
            Assert.IsNotNull(message);
            Assert.IsTrue(position < message.Count);
            Message messageToGet = message[position];


            //Execute
            Message? loadedMessage= _messageRepository.GetMessageById(messageToGet.Id);

            //Assert
            Assert.IsNotNull(loadedMessage);
        }
        
        public void Cannot_Get_Message_By_Invalid_Id()
        {
            //Arrange

            //Execute
            Message? loadedMessage= _messageRepository.GetMessageById(Guid.Empty);

            //Assert
            Assert.IsNull(loadedMessage);
        }
        [DataRow(0)]
        [TestMethod]
        public void Can_Delete_Message(int position)
        {
            //Arrange
            var Messages = _messageRepository.GetAllMessage();
            Assert.IsNotNull(Messages);
            var count= Messages.Count();
            var messages= Messages.ElementAt(position);
            Assert.IsNotNull(messages);

            //Execute
            _messageRepository.DeleteMessage(messages);
            _unitOfWork.SaveChages();

            //Assert
            Messages = _messageRepository.GetAllMessage();
            Assert.AreEqual(count - 1, Messages.Count());
            var Deletemessage = _messageRepository.GetMessageById(messages.Id);
            Assert.IsNotNull(messages);
        }
        [DataRow(0)]
        [TestMethod]

        public void Can_Update_Message(int position)
        {
            //Arrange
            var Messages = _messageRepository.GetAllMessage();
            Assert.IsNotNull(Messages);
            var message= Messages.ElementAt(position);
            Assert.IsNotNull(message);

            //Execute
            _messageRepository.UpdateMessage(message);
            _unitOfWork.SaveChages();

            //Assert
            var updatedMessage = _messageRepository.GetMessageById(message.Id);
            Assert.IsNotNull(updatedMessage);
        
        }

    }
}
