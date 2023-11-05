using NUnit.Framework;
using N5NowWebApi.Controllers;
using N5NowWebApi.Commands;
using N5NowWebApi.Queries;
using MediatR;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain;
using System.Security;

namespace TestProject
{
    [TestFixture]
    public class PermissionControllerUnitTests
    {
        private PermissionController permissionController;
        private Mock<IMediator> mediatorMock;

        [SetUp]
        public void Setup()
        {
            mediatorMock = new Mock<IMediator>();
            permissionController = new PermissionController(mediatorMock.Object);
        }

        [Test]
        public async Task GetPermissions_Returns_ExpectedResult()
        {
            var permissions = new List<Permission>(); // Define tus datos de prueba

            mediatorMock.Setup(m => m.Send(It.IsAny<GetPermissionListQuery>(), It.IsAny<CancellationToken>()))
                        .ReturnsAsync(permissions);

            var result = await permissionController.GetPermissions();

            Assert.IsInstanceOf<List<Permission>>(result);

            var permissionList = result as List<Permission>;
            Assert.IsNotNull(permissionList);
            Assert.That(permissionList, Is.EqualTo(permissions));
        }

        [Test]
        public async Task GetPermissionById_Returns_ExpectedResult()
        {
            var permission = new Permission(); // Define tus datos de prueba

            int permissionId = 1; // Valor específico del ID de permiso que deseas pasar

            mediatorMock.Setup(m => m.Send(It.Is<GetPermissionByIdQuery>(query => query.Id == permissionId), It.IsAny<CancellationToken>()))
                        .ReturnsAsync(permission);


            var result = await permissionController.GetPermissionById(permissionId);

            Assert.IsInstanceOf<Permission>(result);

            var _permission = result as Permission;
            Assert.IsNotNull(_permission);
            Assert.That(_permission, Is.EqualTo(permission));
        }

        [Test]
        public async Task RequestPermission_Should_Return_RequestedPermission()
        {
            // Arrange
            var expectedPermission = new Permission
            {
                // Definir propiedades del permiso esperado
                NombreEmpleado = "Kevin",
                ApellidoEmpleado = "Bacon",
                TipoPermiso = 1,
                FechaPermiso = DateTime.Now
            };

            mediatorMock.Setup(m => m.Send(It.IsAny<CreatePermissionCommand>(), It.IsAny<CancellationToken>()))
                        .ReturnsAsync(expectedPermission);

            var result = await permissionController.RequestPermission(expectedPermission);

            var _permission = result as Permission;
            Assert.IsNotNull(_permission);
            Assert.That(_permission, Is.EqualTo(expectedPermission));
        }


        [Test]
        public async Task ModifyPermission_Should_Return_ModifyPermission()
        {
            var permissionId = 123; // ID del permiso que deseas actualizar
            var updatedPermission = new Permission
            {
                Id = permissionId,
                NombreEmpleado = "Tom",
                ApellidoEmpleado = "Cruise",
                TipoPermiso = 1,
                FechaPermiso = DateTime.Now
            };

            mediatorMock.Setup(m => m.Send(It.IsAny<UpdatePermissionCommand>(), It.IsAny<CancellationToken>()))
                        .ReturnsAsync(updatedPermission);

            // Act
            var result = await permissionController.ModifyPermission(updatedPermission);

            var _permission = result as Permission;
            Assert.IsNotNull(_permission);
            Assert.That(_permission, Is.EqualTo(updatedPermission));
        }
    }
}