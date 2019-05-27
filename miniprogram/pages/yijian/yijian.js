// pages/yijian/yijian.js
var util = require('../../util/util.js');
Page({

  /**
   * 页面的初始数据
   */
  data: {
    nameInputValue: '',
    contentInputValue: '',
    time: '',
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function (options) {

  },
  nameval: function (e) {
    var val = e.detail.value;
    this.data.nameInputValue = val;
  },
  contentval: function (e) {
    var val = e.detail.value;
    this.setData({
      contentInputValue: val
    })
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

  },
  buttonTap: function (e) {
    var TIME = util.formatTime(new Date());
    this.setData({
      time: TIME
    })
    const db = wx.cloud.database();
    db.collection('advices').add({
      data: {
        phone: this.data.nameInputValue,
        content: this.data.contentInputValue,
        time: this.data.time,
        
      },
      success: res => {
        // 在返回结果中会包含新创建的记录的 _id
        this.showCommitSuccessToast();
        console.log('[数据库] [新增记录] 成功，记录 _id: ', res._id)
        this.setData({ informId: res._id })
      },
      fail: err => {
        wx.showToast({
          icon: 'none',
          title: '新增记录失败'
        })
        console.error('[数据库] [新增记录] 失败：', err)
      }
    })


  },
  showCommitSuccessToast: function () {
    //显示操作结果
    wx.showToast({
      title: "反馈成功",
      duration: 1000,
      icon: "success"
    })
  }
})
