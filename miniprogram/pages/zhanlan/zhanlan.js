// pages/zhanlan/zhanlan.js
Page({

  /**
   * 页面的初始数据
   */
  data: {
    status: true
  }, //重新设置通知的信息列表
  sett: function (data) {
    console.log("YES");

    data.reverse();
    this.setData({
      postList: data
    })
    wx.stopPullDownRefresh()
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function (options) {
    this.settt();
  },
  settt: function (data) {
    const db = wx.cloud.database()

    // 查询当前用户所有的 counters
    db.collection('zhanlan').get({
      success: res => {
        console.log(res.data.length)
        this.sett(res.data);
        this.setData({ status: true })
        if (res.data.length == 0)
          this.setData({ status: false })
        console.log('[数据库] [查询记录] 成功: ', res)
      },
      fail: err => {
        wx.showToast({
          icon: 'none',
          title: '查询记录失败'
        })
        console.error('[数据库] [查询记录] 失败：', err)
      }
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

  }
})