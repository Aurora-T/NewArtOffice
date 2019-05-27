// pages/people/people.js
var app = getApp()
var util = require('../../util/util.js')
Page({

  /**
   * 页面的初始数据
   */
  data: {
   
    noInputValue:'',    //学号
    phoneInputValue: '',
    nameInputValue: '',
    qqInputValue: '',
    room: '',
    index: 0,      //楼号在数组中的位置
    sex:'',
    openid:'',
    status: false,
    status1:'',   //男性
    status2:'',   //女性
    counterID:'',  //用户的openid
    identity:false,
    manage:false
  },
  noval: function (e) {
    var val = e.detail.value;
    this.data.noInputValue = val;
  },
  nameval: function (e) {
    var val = e.detail.value;
    this.data.nameInputValue = val;
  },
 roomval:function(e)
{
   var val = e.detail.value;
   this.data.room = val;
},
  qqval: function (e) {
    var val = e.detail.value;
    this.data.qqInputValue = val;
  },
  phoneval: function (e) {
    var val = e.detail.value;
    this.setData({
      phoneInputValue: val
    })
  },
  radiochange: function (e) {
    var val = e.detail.value
    console.log(val)
    this.setData({
      sex: val
    })
  },
  buttonTap: function (e) {
    
    const db = wx.cloud.database()
    if(this.data.sex=='男')
    this.setData({
      status1:'yes',
      status2:''
    })
    if (this.data.sex == '女')
      this.setData({
        status2:'yes',
        status1:''
      })
    if (this.data.noInputValue == '' || this.data.phoneInputValue == '' || this.data.room == '' || this.data.qqInputValue == '' || this.data.nameInputValue == '' || this.data.sex == '' || this.data.index==0)
      wx.showToast({
        icon: 'none',
        title: '您有一或多项信息未填写'
      })
      else{
    if(this.data.counterID=='') {
      db.collection('users').add({
        // data 字段表示需新增的 JSON 数据
        data: {
          identity: this.data.identity,
          name: this.data.nameInputValue,
          qq: this.data.qqInputValue,
          no: this.data.noInputValue,
          phone: this.data.phoneInputValue,
          sex: this.data.sex,
          lou: this.data.array[this.data.index],
          room: this.data.room,
          index: this.data.index,
          status1: this.data.status1,
          status2: this.data.status2,
          identity: this.data.identity,
          manage: this.data.manage
        },
        success: res => {
          console.log(res._id);
          var id=res._id
          this.setData({
            counterID: res._id
            });
          this.showCommitSuccessToast();
        }
      })
    }
    //点击提交后修改此用户的个人信息
    else
    {db.collection('users').doc(this.data.counterID).set({
      data: {
        identity: this.data.identity,
        name: this.data.nameInputValue,
        qq: this.data.qqInputValue,
        no: this.data.noInputValue,
        phone: this.data.phoneInputValue,
        sex:this.data.sex,
        lou:this.data.array[this.data.index],
        room:this.data.room,
        index: this.data.index,
        status1: this.data.status1,
        status2:this.data.status2,
        identity:this.data.identity,
        manage: this.data.manage
      },
      success: res => {
        // 在返回结果中会包含新创建的记录的 _id
        
        wx.showToast({
          title: '修改成功',
        })
        console.log('[数据库] [新增记录] 成功，记录 _id: ', res._id)
      },
      fail: err => {
        wx.showToast({
          icon: 'none',
          title: '新增记录失败'
        })
        console.error('[数据库] [新增记录] 失败：', err)
      }
    })
    }
      }
  },
  showCommitSuccessToast: function () {
    //显示操作结果
    wx.showToast({
      title: "提交成功",
      duration: 1000,
      icon: "success"
    })
  },
  //判断楼号是否改变
  bindPickerChange: function (e) {
    console.log('picker发送选择改变，携带值为', e.detail.value)

    this.setData({
      index: e.detail.value,
      status: true
    })
  },
  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function (options) {
//查询此用户是否已经填写过个人信息
    const db = wx.cloud.database()
   
    var openid = getApp().globalData.openid
    // 查询当前用户所有的 counters
    db.collection('users').where({
      _openid: openid
    }).get({
      success: res => {
        console.log(res.data.length)
        this.setData({
          nameInputValue: res.data[0].name,
          qqInputValue: res.data[0].qq,
          noInputValue: res.data[0].no,
          phoneInputValue: res.data[0].phone,
          sex: res.data[0].sex,
          index: res.data[0].index,
          status1: res.data[0].status1,
          status2: res.data[0].status2,
          status: true,
          room: res.data[0].room,
          counterID:res.data[0]._id,
          identity:res.data[0].identity,
          manage:res.data[0].manage
        })
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
  
  }
,
 
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