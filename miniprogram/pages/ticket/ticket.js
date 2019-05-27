// pages/ticket/ticket.js
Page({

  /**
   * 页面的初始数据
   */
  data: {
    nameInputValue: '',
    noInputValue: '',
  },
  bindPickerChange2: function (e) {
    console.log('picker发送选择改变，携带值为', e.detail.value)

    this.setData({
      date: e.detail.value,
      status2: true
    })
  },
  noval: function (e) {
    var val = e.detail.value;
    this.data.noInputValue = val;
  },
  nameval: function (e) {
    var val = e.detail.value;
    this.data.nameInputValue = val;
  },
  noval1: function (e) {
    var val = e.detail.value;
    this.data.noInputValue = val;
  },
  nameval1: function (e) {
    var val = e.detail.value;
    this.data.nameInputValue = val;
  },
  noval2: function (e) {
    var val = e.detail.value;
    this.data.noInputValue = val;
  },
  nameval2: function (e) {
    var val = e.detail.value;
    this.data.nameInputValue = val;
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function (options) {

  },

  /**
   * 生命周期函数--监听页面初次渲染完成
   */
  onReady: function () {

  },

  /**
   * 生命周期函数--监听页面显示
   */
  onShow: function () {

  },

  /**
   * 生命周期函数--监听页面隐藏
   */
  onHide: function () {

  },

  /**
   * 生命周期函数--监听页面卸载
   */
  onUnload: function () {

  },

  /**
   * 页面相关事件处理函数--监听用户下拉动作
   */
  onPullDownRefresh: function () {

  },

  /**
   * 页面上拉触底事件的处理函数
   */
  onReachBottom: function () {

  },

  /**
   * 用户点击右上角分享
   */
  onShareAppMessage: function () {

  }
})