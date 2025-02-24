function AddListener( )
	account.onValueChanged:AddListener(OnDebugAccountMessages)
	password.onValueChanged:AddListener(OnDebugPasswordMessages)
	loginButton.onClick:AddListener(OnLoginClick)
	registeredButton.onClick:AddListener(OnRegisteredClick)
	closeButton.onClick:AddListener(OnCloseClick)
end

function RemoveListener()
	account.onValueChanged:RemoveAllListeners()
	password.onValueChanged:RemoveAllListeners()
	loginButton.onClick:RemoveAllListeners()
end

--登录按键处理
function OnLoginClick()
	--验证账号和密码
	--这里未来可以添加注册和根据数据库进行验证登录
	if CS.Data.Instance.accountDic:ContainsKey(accountText) then
		local tempText=CS.Data.Instance:FindContentInDic(accountText)
		if(tempText==passwordText) then
			CS.UnityEngine.Debug.Log("登录成功"..accountText..passwordText)
		else
			error:SetActive(true)
		    OnErrorMessage("账号已有，密码错误")
		end
	else
		error:SetActive(true)
		OnErrorMessage("未注册账号，请注册账号")
	end
end
--注册按键处理
function OnRegisteredClick()
	if CS.Data.Instance.accountDic:ContainsKey(accountText) then
		--CS.UnityEngine.Debug.Log("注册失败".."这个账号已注册，请重新输入账号密码")
		OnErrorMessage("这个账号已注册，请重新输入账号密码")
		--CS.Add_UI.Instance:AddText(partentTransform,"这个账号已注册，请重新输入账号密码")
	else
		CS.Data.Instance.accountDic:Add(accountText,passwordText)
		--CS.UnityEngine.Debug.Log("注册成功")
		CS.Data.Instance:WriteAccountData()
		error:SetActive(true)
		OnErrorMessage("注册成功，请登录")
	end
end

--关闭按键处理
function OnCloseClick()
	error:SetActive(false)
end


--对输入的账号进行处理
function OnDebugAccountMessages(input)
	accountText=input;
end

--对输入的密码进行处理
function OnDebugPasswordMessages(input)
	passwordText=input;
end

--报错信息
function OnErrorMessage(errorMesage)
	errotText.text=errorMesage
end