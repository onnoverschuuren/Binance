﻿using Binance.Api.WebSocket.Events;
using Binance.Orders;
using System;
using Xunit;

namespace Binance.Tests.Api.WebSocket.Events
{
    public class OrderUpdateEventArgsTest
    {
        [Fact]
        public void Throws()
        {
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

            var symbol = Symbol.BTC_USDT;
            var id = 123456;
            var clientOrderId = "test-order";
            decimal price = 4999;
            decimal originalQuantity = 1;
            decimal executedQuantity = 0.5m;
            var status = OrderStatus.PartiallyFilled;
            var timeInForce = TimeInForce.IOC;
            var orderType = OrderType.Market;
            var orderSide = OrderSide.Sell;
            decimal stopPrice = 5000;
            decimal icebergQuantity = 0.1m;

            var order = new Order(symbol, id, clientOrderId, price, originalQuantity, executedQuantity, status, timeInForce, orderType, orderSide, stopPrice, icebergQuantity, timestamp);

            var orderExecutionType = OrderExecutionType.New;
            var orderRejectedReason = OrderRejectedReason.None;
            var newClientOrderId = "new-test-order";

            Assert.Throws<ArgumentException>("timestamp", () => new OrderUpdateEventArgs(-1, order, orderExecutionType, orderRejectedReason, newClientOrderId));
            Assert.Throws<ArgumentException>("timestamp", () => new OrderUpdateEventArgs(0, order, orderExecutionType, orderRejectedReason, newClientOrderId));
            Assert.Throws<ArgumentNullException>("order", () => new OrderUpdateEventArgs(timestamp, null, orderExecutionType, orderRejectedReason, newClientOrderId));
        }

        [Fact]
        public void Properties()
        {
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

            var symbol = Symbol.BTC_USDT;
            var id = 123456;
            var clientOrderId = "test-order";
            decimal price = 4999;
            decimal originalQuantity = 1;
            decimal executedQuantity = 0.5m;
            var status = OrderStatus.PartiallyFilled;
            var timeInForce = TimeInForce.IOC;
            var orderType = OrderType.Market;
            var orderSide = OrderSide.Sell;
            decimal stopPrice = 5000;
            decimal icebergQuantity = 0.1m;

            var order = new Order(symbol, id, clientOrderId, price, originalQuantity, executedQuantity, status, timeInForce, orderType, orderSide, stopPrice, icebergQuantity, timestamp);

            var orderExecutionType = OrderExecutionType.New;
            var orderRejectedReason = OrderRejectedReason.None;
            var newClientOrderId = "new-test-order";

            var args = new OrderUpdateEventArgs(timestamp, order, orderExecutionType, orderRejectedReason, newClientOrderId);

            Assert.Equal(timestamp, args.Timestamp);
            Assert.Equal(order, args.Order);
            Assert.Equal(orderExecutionType, args.OrderExecutionType);
            Assert.Equal(orderRejectedReason, args.OrderRejectedReason);
            Assert.Equal(newClientOrderId, args.NewClientOrderId);
        }
    }
}