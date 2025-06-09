using litfibretestapi.Controllers;
using litfibretestapi.Models;
using litfibretestapi.Enums;
using Microsoft.AspNetCore.Mvc;


namespace litfibretestapi.Tests;


public class SlotControllerTests
{
    private readonly SlotController _controller;

    public SlotControllerTests()
    {
        _controller = new SlotController();
    }

    [Fact]
    public void GetSlotsReturnsOKWhenAppointmentTypeIsValid()
    {
        // Arrange
        string type = "Installation";

        // Act
        var result = _controller.GetSlots(type);

        // Assert
        var okResult = Assert.IsType<JsonResult>(result);
        Assert.IsType<List<Slot>>(okResult.Value);
    }

    [Fact]
    public void GetSlotsReturnsNotFoundWhenAppointmentTypeIsInvalid()
    {
        var result = _controller.GetSlots("InvalidType");

        var notFound = Assert.IsType<NotFoundObjectResult>(result);
        Assert.Equal("Appointment type not found", notFound.Value);
    }
}